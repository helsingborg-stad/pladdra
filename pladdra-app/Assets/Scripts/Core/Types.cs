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
        public new Vector3 position { get; set; }

        [JsonProperty("rotation")]
        public new Quaternion rotation { get; set; }
    }

    public class CreateBlockInput : Pladdra.API.Types.CreateBlockInput
    {
        [JsonRequired]
        public new Vect3Input position { get; set; }

        [JsonRequired]
        public new QuatInput rotation { get; set; }
    }

    public class UpdateBlockInput : Pladdra.API.Types.CreateBlockInput
    {
        public new Vect3 position { get; set; }

        public new Quat rotation { get; set; }
    }

    public class Workspace : Pladdra.API.Types.Workspace
    {
        [JsonProperty("blocks")]
        public new ModelBlockConnection blocks { get; set; }
    }

    public class ModelBlockConnection : Pladdra.API.Types.ModelBlockConnection
    {
        public new List<Block> items { get; set; }
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
