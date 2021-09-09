using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using GraphQL;

namespace Pladdra.Core.Types
{
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

    public class Block : Pladdra.API.Types.Block
    {
        [JsonProperty("position")]
        public new Vect3 position { get; set; }

        [JsonProperty("rotation")]
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
}
