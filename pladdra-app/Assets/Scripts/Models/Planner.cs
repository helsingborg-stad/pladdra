using System;
using System.Collections.Generic;
using System.Numerics;

using Pladdra.Core;
namespace Pladdra.MVC.Models
{
    public class Planner : IModel
    {
        public string workspaceID;
        public Grid grid
        {
            get
            {
                App.GetModel<Grid>(out var instance);
                return instance;
            }
        }
        private Dictionary<string, Pladdra.API.Types.Block> blocks;
        public string selectedBlockID;
    }
}
