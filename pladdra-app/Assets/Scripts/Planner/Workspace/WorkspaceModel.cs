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
    public class WorkspaceModel : Pladdra.Core.Types.Workspace
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
        public event BlockEventHandler OnBlockDeleted;
        public event BlockEventHandler OnBlockPositionChanged;
        public event BlockEventHandler OnBlockRotationChanged;
        public delegate void BlockEventHandler(string id);

        private Savable<WorkspaceModel> savable;

        private List<Pladdra.Core.Types.Block> items
        {
            get
            {
                if (blocks == null)
                {
                    blocks = new Pladdra.Core.Types.ModelBlockConnection();
                    blocks.items = new List<Pladdra.Core.Types.Block>();
                }

                return blocks.items;
            }

            set { blocks.items = value; }
        }

        public Pladdra.Core.Types.Block GetBlock(string id)
        {
            List<Pladdra.Core.Types.Block> item = items.Where(item => item.id == id).ToList();
            return item[0];
        }

        public List<Pladdra.Core.Types.Block> ListBlocks() => items;

        public void CreateBlock(Core.Types.CreateBlockInput input, out Pladdra.Core.Types.Block createdItem)
        {
            string serializedJson = JsonConvert.SerializeObject(input);
            createdItem = (Pladdra.Core.Types.Block)JsonConvert.DeserializeObject<Pladdra.Core.Types.Block>(serializedJson);
            items.Insert(0, createdItem);
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
            Pladdra.Core.Types.Block updatedItem = JsonConvert.DeserializeObject<Pladdra.Core.Types.Block>(serializedJson);
            Pladdra.Core.Types.Block match = items.Find(item => item.id.Contains(updatedItem.id));

            items.ForEach(item =>
            {
                if (item.id == updatedItem.id)
                {
                    if (updatedItem.position != item.position)
                    {
                        item.position = updatedItem.position;
                        if (OnBlockPositionChanged != null)
                            OnBlockPositionChanged(item.id);
                    }

                    if (updatedItem.rotation != item.rotation)
                    {
                        item.rotation = updatedItem.rotation;
                        if (OnBlockRotationChanged != null)
                            OnBlockRotationChanged(item.id);
                    }

                    // Additional changes to notify
                    // 
                }
            });
        }

        public void DeleteBlock(string id)
        {
            List<Core.Types.Block> updatedItems = items.Where(item => item.id != id).ToList();
            items = updatedItems;

            if (OnBlockDeleted != null)
                OnBlockDeleted(id);
        }

        public void Load()
        {
            MakeSavable();
            savable.Load();
        }

        public void Save()
        {
            MakeSavable();
            savable.Save();
        }

        private void MakeSavable()
        {
            if (savable == null)
                savable = new Savable<WorkspaceModel>();

            savable.fileName = "workspaces/" + (id ?? "workspace") + ".json";
            savable.instance = this;
        }

        public string UUID()
        {
            return System.Guid.NewGuid().ToString();
        }
    }
}
