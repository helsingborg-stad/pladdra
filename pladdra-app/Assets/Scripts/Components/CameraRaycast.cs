using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CameraRaycast : MonoBehaviour {
    public Camera ARCamera;
    public GameObject arMarkerPrefab;
    public ARPlaneManager arPlaneManager;

    public ARRaycastManager m_RaycastManager;

    public int layerMask = 1 << 10;

    GameObject createdARMarker;

    private Vector2 screenCenter;


    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start() {
        //createdARMarker = Instantiate(arMarkerPrefab, Vector3.zero, Quaternion.identity);

        screenCenter = new Vector2(Screen.currentResolution.width / 2, Screen.currentResolution.height / 2);
    }

    void placeSphereAtPhysical() {
        Ray ray = ARCamera.ScreenPointToRay(screenCenter);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, float.MaxValue)) {
            Debug.Log("hit: "+hit.transform.name);
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
