using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour {
    public Camera gameCamera;
    public GameObject arMarkerPrefab;

    GameObject createdARMarker;

    // Start is called before the first frame update
    void Start() {
        createdARMarker = Instantiate(arMarkerPrefab, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;
            
            // Do something with the object that was hit by the raycast.
        }
    }
}
