using Piglet;
using UnityEngine;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pladdra
{
    /// <summary>
    /// This MonoBehaviour provides a minimal example for using
    /// Piglet to import glTF models at runtime.
    /// </summary>
    public class PigletImport : MonoBehaviour
    {
        /// <summary>
        /// The currently running glTF import task.
        /// </summary>
        private GltfImportTask _task;

        /// <summary>
        /// Root GameObject of the imported glTF model.
        /// </summary>
        private GameObject _model;

        /// <summary>
        /// Unity callback that is invoked before the first frame.
        /// Create the glTF import task and set up callbacks for
        /// progress messages and successful completion.
        /// </summary>
        public void Import()
        {
            // Note: To import a local .gltf/.glb/.zip file, you may
            // instead pass an absolute file path to GetImportTask
            // (e.g. "C:/Users/Joe/Desktop/piggleston.glb"), or a byte[]
            // array containing the raw byte content of the file. 
            string path = Path.Combine(App.CachePath, "downloads/f9e456fd-7988-4665-89f1-1da498f6b46f.glb");
            Debug.Log(path);

            // byte[] buffer = File.ReadAllBytes(path);

            // Debug.Log(buffer);
            // foreach (byte s in buffer)
            // {
            //     // Printing the binary array value of
            //     // the file contents
            //     Console.WriteLine(s);
            // }
            _task = RuntimeGltfImporter.GetImportTask(path, new GltfImportOptions { AutoScaleSize = 0.01f, AutoScale = true });
            _task.OnProgress = OnProgress;
            _task.OnCompleted = OnComplete;
        }

        /// <summary>
        /// Callback that is invoked by the glTF import task
        /// after it has successfully completed.
        /// </summary>
        /// <param name="importedModel">
        /// the root GameObject of the imported glTF model
        /// </param>
        private void OnComplete(GameObject importedModel)
        {
            _model = importedModel;
            Debug.Log("Success!");
        }

        /// <summary>
        /// Callback that is invoked by the glTF import task
        /// to report intermediate progress.
        /// </summary>
        /// <param name="step">
        /// The current step of the glTF import process.  Each step imports
        /// a different type of glTF entity (e.g. textures, materials).
        /// </param>
        /// <param name="completed">
        /// The number of glTF entities (e.g. textures, materials) that have been
        /// successfully imported for the current import step.
        /// </param>
        /// <param name="total">
        /// The total number of glTF entities (e.g. textures, materials) that will
        /// be imported for the current import step.
        /// </param>
        private void OnProgress(GltfImportStep step, int completed, int total)
        {
            Debug.LogFormat("{0}: {1}/{2}", step, completed, total);
        }

        /// <summary>
        /// Unity callback that is invoked after every frame.
        /// Here we call MoveNext() to advance execution
        /// of the glTF import task. Once the model has been successfully
        /// imported, we auto-spin the model about the y-axis.
        /// </summary>
        void Update()
        {
            // // advance execution of glTF import task
            if (_task != null)
            {
                _task.MoveNext();
            }

            // spin model about y-axis
            if (_model != null)
                _model.transform.Rotate(0, 1, 0);
        }
    }
}