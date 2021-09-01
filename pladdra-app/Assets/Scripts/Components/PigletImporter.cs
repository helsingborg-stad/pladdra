using Piglet;
using UnityEngine;
using UnityEngine.Events;


namespace Pladdra.Components {
	public class PigletImporter : MonoBehaviour {
		public static UnityEvent<GameObject> onImportFinished = new UnityEvent<GameObject>();
		private static GltfImportTask _task = null;

		public static void startImport(string assetPath) {
			GltfImportOptions options = new GltfImportOptions();
			options.ImportAnimations = false;
			options.ShowModelAfterImport = false;

			_task = RuntimeGltfImporter.GetImportTask(assetPath, options);
			_task.OnProgress = OnProgress;
			_task.OnCompleted = OnComplete;
		}

		private static void OnProgress(GltfImportStep step, int completed, int total) {
			Debug.LogFormat("{0}: {1}/{2}", step, completed, total);
		}

		private static void OnComplete(GameObject importedModel) {
			Debug.Log("Success!");
			onImportFinished.Invoke(importedModel);
			_task = null;
		}

		void Update () {
			if (_task != null) {
				_task.MoveNext();
			}
		}
	}
}