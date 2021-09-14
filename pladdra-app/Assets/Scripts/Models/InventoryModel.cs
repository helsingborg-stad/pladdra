using UnityEngine;
using Pladdra.MVC.Models;
using System.Collections.Generic;


namespace Pladdra.MVC.Models
{
    public class InventoryModel
    {
        [System.Serializable]
        public struct InventoryCategory {
            public string name;
            public List<AssetModel.Asset> items;
        }
        
    }
}
