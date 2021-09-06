using Piglet;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Pladdra.Components {
	public class PigletImporter : MonoBehaviour {
		public delegate void OnImportFinished(GameObject imported);

		private static Dictionary<string, GltfImportTask> _importTasks = new Dictionary<string, GltfImportTask>();

		public static void import(string assetPath, OnImportFinished onImportFinished) {
			GltfImportOptions options = new GltfImportOptions();
			options.ImportAnimations = false;
			options.ShowModelAfterImport = false;

			GltfImportTask _task = RuntimeGltfImporter.GetImportTask(assetPath, options);
			_task.OnProgress = OnProgress;
			_task.OnCompleted = OnComplete;

			_importTasks.Add(assetPath, _task);

			void OnComplete(GameObject importedModel) {
				Debug.Log("Success!");
				// onImportFinished.Invoke(importedModel);
				onImportFinished(importedModel);
				_importTasks.Remove(assetPath);
			}
		}

		private static void OnProgress(GltfImportStep step, int completed, int total) {
			Debug.LogFormat("{0}: {1}/{2}", step, completed, total);
		}
		
		void Update () {
			foreach(GltfImportTask task in _importTasks.Values.ToList()) {
				task.MoveNext();
			}
		}
	}
}