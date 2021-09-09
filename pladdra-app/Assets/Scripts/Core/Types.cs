using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using GraphQL;

namespace Pladdra.Core.Types
{
    public class Quat
    {
        #region members
        [JsonProperty("x")]
        public int x { get; set; }

        [JsonProperty("y")]
        public int y { get; set; }

        [JsonProperty("z")]
        public int z { get; set; }

        [JsonProperty("w")]
        public int w { get; set; }
        #endregion
    }

    public class Vect3
    {
        #region members
        [JsonProperty("x")]
        public float x { get; set; }

        [JsonProperty("y")]
        public float y { get; set; }

        [JsonProperty("z")]
        public float z { get; set; }
        #endregion
    }

    public class Block : Pladdra.API.Types.Block
    {
        [JsonProperty("position")]
        public Vect3 position { get; set; }

        [JsonProperty("rotation")]
        public Quat rotation { get; set; }
    }

    public class Workspace : Pladdra.API.Types.Workspace
    {

        [JsonProperty("blocks")]
        public ModelBlockConnection blocks { get; set; }
    }

    public class ModelBlockConnection : Pladdra.API.Types.ModelBlockConnection
    {
        public List<Block> items { get; set; }
    }
}
