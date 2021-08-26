using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CameraRaycast : MonoBehaviour {
    public Camera ARCamera;
    public GameObject arMarkerPrefab;
    GameObject createdARMarker;


    void placeSphereAtPhysical() {
        RaycastHit hit;


        if (Physics.Raycast(ARCamera.transform.position, ARCamera.transform.forward, out hit, float.MaxValue)) {
            ARPlane plane = hit.transform.GetComponent<ARPlane>();

            if (plane == null) return;

            if (createdARMarker == null) {
                createdARMarker = Instantiate(arMarkerPrefab, hit.point, Quaternion.identity);
            } else {
                createdARMarker.transform.position = hit.point;
            }
        }
    }
 

    // Update is called once per frame
    void FixedUpdate() {
        placeSphereAtPhysical();
    }
}
