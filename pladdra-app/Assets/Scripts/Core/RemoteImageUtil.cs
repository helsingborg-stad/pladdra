using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


public static class RemoteImageUtil {
    public delegate void OnRemoteImageLoaded(Texture2D asset);

	/// <summary>
	/// Loads an image in to a <see cref="UnityEngine.Texture2D"><c>Texture2D</c></see> from a remote location
	/// You need to call this method inside a <see cref="MonoBehaviour.StartCoroutine(IEnumerator)" /> method
	/// </summary>
	public static IEnumerator loadRemoteImage(string path, OnRemoteImageLoaded callback) {
		UnityWebRequest request = UnityWebRequestTexture.GetTexture(path);

		// Wait for download to complete
		yield return request.SendWebRequest();

		if (request.isNetworkError || request.isHttpError) {
			Debug.LogError(request.error);
			callback(null);
		} else {
			Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
			callback(tex);
		}
	}
}