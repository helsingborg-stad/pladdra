using Piglet;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using System.Threading;
namespace Pladdra.Components
{
    public class PigletImporter : MonoBehaviour
    {

        public static Thread mainThread;

        public void Start()
        {
            mainThread = System.Threading.Thread.CurrentThread;
        }
        public static bool isMainThread()
        {
            return mainThread.Equals(System.Threading.Thread.CurrentThread);
        }

        public delegate void OnErrorDelegate(System.Exception e);
        public delegate void OnSuccessDelegate(GameObject imported);
        public delegate void OnImportFinished(GameObject imported);

        private static Dictionary<string, GltfImportTask> _importTasks = new Dictionary<string, GltfImportTask>();

        public static bool processTasks;

        public static void import(string assetPath, OnSuccessDelegate OnSuccess, OnErrorDelegate OnError)
        {
            GltfImportOptions options = new GltfImportOptions();
            options.ImportAnimations = false;
            options.ShowModelAfterImport = false;

            GltfImportTask _task = RuntimeGltfImporter.GetImportTask(assetPath, options);
            _task.OnProgress = OnProgress;
            _task.OnCompleted = HandleComplete;
            _task.OnException = HandleError;

            _importTasks.Add(assetPath, _task);

            void HandleComplete(GameObject importedModel)
            {
                OnSuccess(importedModel);
                _importTasks.Remove(assetPath);
            }
            void HandleError(System.Exception e)
            {
                OnError(e);
                _importTasks.Remove(assetPath);
            }
        }

        private static void OnProgress(GltfImportStep step, int completed, int total)
        {
            // Debug.LogFormat("{0}: {1}/{2}", step, completed, total);
        }

        void Update()
        {
            if (_importTasks.Count > 0)
            {
                foreach (GltfImportTask task in _importTasks.Values.ToList())
                {
                    task.MoveNext();
                }

            }
        }
    }
}