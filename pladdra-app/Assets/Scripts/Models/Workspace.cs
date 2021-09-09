using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

using Newtonsoft.Json;

using Pladdra;
using Pladdra.Core;

namespace Pladdra.MVC.Models
{
    [System.Serializable]
    public class Workspace : Pladdra.API.Types.Workspace
    {
        private Savable<Workspace> savable;

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
                savable = new Savable<Workspace>();

            savable.fileName = "workspaces/" + (id ?? "workspace") + ".json";
            savable.instance = this;
        }
    }
}
