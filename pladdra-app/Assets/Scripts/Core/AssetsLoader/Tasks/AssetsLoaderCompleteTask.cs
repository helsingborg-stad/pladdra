using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

namespace Pladdra.Core
{
    using Pladdra.Components;
    using Pladdra.MVC.Models;

    public class AssetsLoaderCompleteTask : AssetsLoaderTask
    {
        public AssetsLoaderCompleteTask(AssetsLoader context) : base(context)
        { }

        public override void Handler(Core.Types.Asset asset)
        {

            context.completedQueues++;
            Debug.Log("AssetsLoaderCompleteTask: completedQueues: " + context.completedQueues + "/" + context.initialQueues);
            if (context.completedQueues == context.initialQueues
                && context.OnCompletePreload != null)
                context.OnCompletePreload();
        }
    }
}