using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;


namespace Pladdra.Core.Types
{
    public class Asset : API.Types.Asset
    {
        [JsonProperty("previewTexturePath")]
        public string previewTexturePath;

        [JsonProperty("meshPath")]
        public string meshPath;

        [JsonProperty("prefabPath")]
        public string prefabPath;
    }

    public class Block : Pladdra.API.Types.Block
    {
        [JsonProperty("position")]
        // [JsonConverter(typeof(Newtonsoft.Json.VectorConverter))]
        public new Vector3 position { get; set; }

        [JsonProperty("rotation")]
        public new Quaternion rotation { get; set; }
    }

    public class CreateBlockInput : Pladdra.API.Types.CreateBlockInput
    {
        [JsonRequired]
        public new Vector3 position { get; set; }

        [JsonRequired]
        public new Quaternion rotation { get; set; }
    }

    public class UpdateBlockInput : Pladdra.API.Types.CreateBlockInput
    {
        public new Vector3 position { get; set; }

        public new Quaternion rotation { get; set; }
    }

    public class Workspace : Pladdra.API.Types.Workspace
    {
        private ModelBlockConnection _blocks { get; set; }

        [JsonProperty("blocks")]
        public new ModelBlockConnection blocks
        {
            get
            {
                if (_blocks == null)
                    _blocks = new Pladdra.Core.Types.ModelBlockConnection();

                return _blocks;
            }

            set { _blocks = value; }
        }
    }

    public class ModelBlockConnection : Pladdra.API.Types.ModelBlockConnection
    {
        private List<Pladdra.Core.Types.Block> _items { get; set; }

        [JsonProperty("items")]
        public new List<Pladdra.Core.Types.Block> items
        {
            get
            {
                if (_items == null)
                    _items = new List<Pladdra.Core.Types.Block>();

                return _items;
            }

            set { _items = value; }
        }
    }
    public class Quat : Pladdra.API.Types.Quat
    {
        #region members
        [JsonProperty("x")]
        public new float x { get; set; }

        [JsonProperty("y")]
        public new float y { get; set; }

        [JsonProperty("z")]
        public new float z { get; set; }

        [JsonProperty("w")]
        public new float w { get; set; }
        #endregion
    }

    public class QuatInput : Pladdra.API.Types.QuatInput
    {
        [JsonRequired]
        public new float x { get; set; }

        [JsonRequired]
        public new float y { get; set; }

        [JsonRequired]
        public new float z { get; set; }

        [JsonRequired]
        public new float w { get; set; }
    }

    public class Vect3 : Pladdra.API.Types.Vect3
    {
        #region members
        [JsonProperty("x")]
        public new float x { get; set; }

        [JsonProperty("y")]
        public new float y { get; set; }

        [JsonProperty("z")]
        public new float z { get; set; }
        #endregion
    }

    public class Vect3Input : Pladdra.API.Types.Vect3Input
    {
        #region members
        [JsonRequired]
        public new float x { get; set; }

        [JsonRequired]
        public new float y { get; set; }

        [JsonRequired]
        public new float z { get; set; }
        #endregion
    }
}
