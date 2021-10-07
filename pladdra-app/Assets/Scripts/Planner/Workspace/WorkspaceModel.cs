using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

using Newtonsoft.Json;

namespace Pladdra.MVC.Models
{
    [System.Serializable]
    public class WorkspaceModel : Pladdra.Core.Types.Workspace, ISaveable
    {
        private string _selectedBlockID;
        public string selectedBlockID
        {
            get { return _selectedBlockID; }
            set
            {
                if (_selectedBlockID != value)
                {
                    string previousID = null;

                    if (value == null && _selectedBlockID != null)
                    {
                        previousID = _selectedBlockID;
                    }

                    _selectedBlockID = value;
                    if (value == null & previousID != null)
                    {
                        if (OnBlockDeselected != null)
                            OnBlockDeselected(previousID);
                    }
                    else if (value != null)
                    {
                        if (OnBlockSelected != null)
                            OnBlockSelected(_selectedBlockID);
                    }

                }
            }
        }

        public event BlockEventHandler OnBlockSelected;
        public event BlockEventHandler OnBlockDeselected;
        public event BlockEventHandler OnBlockCreated;
        public event BlockEventHandler OnBlockUpdated;
        public event BlockEventHandler OnBlockDeleted;
        public event BlockEventHandler OnBlockPositionChanged;
        public event BlockEventHandler OnBlockRotationChanged;
        public delegate void BlockEventHandler(string id);

        private Savable<WorkspaceModel> savable;


        public bool BlockExists(string id)
        {
            List<Pladdra.Core.Types.Block> arr = blocks.items.Where(item => item.id == id).ToList();
            return arr.Count > 0 ? true : false;
        }

        public bool GetBlock(string id, out Pladdra.Core.Types.Block block)
        {
            block = null;
            if (BlockExists(id))
            {
                block = GetBlock(id);
                return true;
            }

            return false;
        }

        public Pladdra.Core.Types.Block GetBlock(string id)
        {
            List<Pladdra.Core.Types.Block> item = blocks.items.Where(item => item.id == id).ToList();
            return JsonConvert.DeserializeObject<Pladdra.Core.Types.Block>(JsonConvert.SerializeObject(item[0]));
        }

        public List<Pladdra.Core.Types.Block> ListBlocks() => blocks.items;

        public void CreateBlock(Core.Types.CreateBlockInput input, out Pladdra.Core.Types.Block createdItem)
        {
            string serializedJson = JsonConvert.SerializeObject(input);
            createdItem = (Pladdra.Core.Types.Block)JsonConvert.DeserializeObject<Pladdra.Core.Types.Block>(serializedJson);
            blocks.items.Insert(0, createdItem);

            // Debug.Log("Created block! Total blocks in workspace: " + blocks.items.Count);
        }

        public void CreateBlock(Core.Types.CreateBlockInput input)
        {
            CreateBlock(input, out Pladdra.Core.Types.Block createdItem);
            if (OnBlockCreated != null)
                OnBlockCreated(createdItem.id);
        }

        public void UpdateBlock(Core.Types.UpdateBlockInput input)
        {
            string serializedJson = JsonConvert.SerializeObject(input);
            Pladdra.Core.Types.Block block = JsonConvert.DeserializeObject<Pladdra.Core.Types.Block>(serializedJson);

            bool positionChanged;
            bool rotationChanged;

            Pladdra.Core.Types.Block existingBlock = blocks.items.Find(item => item.id.Contains(block.id));
            positionChanged = block.position != existingBlock.position;
            rotationChanged = block.rotation != existingBlock.rotation;

            var index = blocks.items.IndexOf(existingBlock);
            blocks.items[index] = block;

            if (positionChanged
                && OnBlockPositionChanged != null)
            {
                // Debug.Log("Updating block position to: " + block.position);
                OnBlockPositionChanged(block.id);
            }

            if (rotationChanged
                && OnBlockRotationChanged != null)
            {
                // Debug.Log("Updating block rotation to: " + block.rotation);
                OnBlockRotationChanged(block.id);
            }

            Debug.Log(serializedJson);
            if (OnBlockUpdated != null)
                OnBlockUpdated(block.id);
        }

        public void UpdateBlock(Pladdra.Core.Types.Block block)
        {
            string serializedJson = JsonConvert.SerializeObject(block);
            Core.Types.UpdateBlockInput input = JsonConvert.DeserializeObject<Core.Types.UpdateBlockInput>(serializedJson);

            UpdateBlock(input);
        }

        public void DeleteBlock(string id)
        {
            List<Core.Types.Block> updatedItems = blocks.items.Where(item => item.id != id).ToList();
            blocks.items = updatedItems;

            if (OnBlockDeleted != null)
                OnBlockDeleted(id);

            // Debug.Log("Delted block! Total blocks in workspace: " + blocks.items.Count);
            blocks.items.ForEach(item =>
            {
                Debug.Log("ID: " + item.id + ". " + "POS: " + item.position + ". " + "ROT: " + item.rotation + ".");
            });
        }

        public void Load()
        {
            MakeSavable(true);
            savable.Load();

            // Debug.Log("ITEMS COUNT ON LOAD: " + blocks.items.Count);
        }

        public void Save()
        {
            MakeSavable();
            savable.Save();
            // Debug.Log("ITEMS COUNT ON SAVE: " + blocks.items.Count);
        }

        private void MakeSavable(bool alwaysMakeNew = false)
        {
            if (savable == null || alwaysMakeNew)
            {
                savable = new Savable<WorkspaceModel>();
                savable.fileName = "workspaces/" + (id ?? "workspace") + ".json";
                savable.instance = this;
            }
        }

        public string UUID()
        {
            return System.Guid.NewGuid().ToString();
        }



        public string ToJson()
        {
            // Debug.Log("ITEMS COUNT ON SAVE: " + blocks.items.Count);
            return JsonConvert.SerializeObject(this);
        }

        public void LoadFromJson(string jsonToLoadFrom)
        {
            WorkspaceModel jsonData = JsonConvert.DeserializeObject<WorkspaceModel>(jsonToLoadFrom);

            var fields = this.GetType().GetFields(BindingFlags.Public);
            foreach (var field in jsonData.GetType().GetFields())
            {
                var value = field.GetValue(jsonData);
                if (value != null)
                    this.GetType().GetField(field.Name).SetValue(this, value);
            }

            var propeties = this.GetType().GetProperties(BindingFlags.Public);
            foreach (var propety in jsonData.GetType().GetProperties())
            {
                var value = propety.GetValue(jsonData);

                if (value != null)
                {
                    try
                    {
                        this.GetType().GetProperty(propety.Name).SetValue(this, value);
                    }
                    catch (System.Exception e)
                    {
                        Debug.Log(value);
                        Debug.Log(propety.Name);

                        if (propety.Name == "blocks")
                        {
                            blocks = jsonData.blocks;
                        }
                    }
                }
            }

            // Debug.Log("ITEMS COUNT ON LOAD: " + blocks.items.Count);
        }

        public string FileNameToUseForData()
        {
            return "workspaces/" + (id ?? "workspace") + ".json"; ;
        }
    }
}
