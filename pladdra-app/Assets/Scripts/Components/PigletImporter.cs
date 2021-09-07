using Piglet;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Pladdra.Components
{
    public class PigletImporter : MonoBehaviour
    {
        public delegate void OnImportFinished(GameObject imported);

        private static Dictionary<string, GltfImportTask> _importTasks = new Dictionary<string, GltfImportTask>();

        private static bool processTasks;

        public static void import(string assetPath, OnImportFinished onImportFinished)
        {
            processTasks = true;
            GltfImportOptions options = new GltfImportOptions();
            options.ImportAnimations = false;
            options.ShowModelAfterImport = false;

            GltfImportTask _task = RuntimeGltfImporter.GetImportTask(assetPath, options);
            _task.OnProgress = OnProgress;
            _task.OnCompleted = OnComplete;

            _importTasks.Add(assetPath, _task);

            void OnComplete(GameObject importedModel)
            {
                Debug.Log("Success!");
                // onImportFinished.Invoke(importedModel);
                onImportFinished(importedModel);
                _importTasks.Remove(assetPath);
                processTasks = false;
            }
        }

        private static void OnProgress(GltfImportStep step, int completed, int total)
        {
            Debug.LogFormat("{0}: {1}/{2}", step, completed, total);
        }

        void Update()
        {
            if (processTasks != true)
                return;
            foreach (GltfImportTask task in _importTasks.Values.ToList())
            {
                task.MoveNext();
            }
        }
    }
}