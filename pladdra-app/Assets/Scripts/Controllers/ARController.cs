using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class ARController : MonoBehaviour
{

    static public ARPlaneManager planeManager;

    void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
        planeManager.planesChanged += OnPlaneChanged;
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnPlaneChanged(ARPlanesChangedEventArgs e)
    {
        // Debug.Log("PLANE ADDED: " + e.added);
        // Debug.Log("PLANE UPDATED: " + e.updated);
        // Debug.Log("PLANE REMOVED: " + e.removed);
    }

    public static void TogglePlaneDetection(bool enabled)
    {
        planeManager.enabled = enabled;

        if (planeManager.enabled)
        {
            SetAllPlanesActive(true);
        }
        else
        {
            SetAllPlanesActive(false);
        }
    }

    public static void TogglePlaneVisualization(bool enable)
    {
        planeManager.requestedDetectionMode = enable ? PlaneDetectionMode.Horizontal : PlaneDetectionMode.None;
    }

    /// <summary>
    /// Iterates over all the existing planes and activates
    /// or deactivates their <c>GameObject</c>s'.
    /// </summary>
    /// <param name="value">Each planes' GameObject is SetActive with this value.</param>
    public static void SetAllPlanesActive(bool value)
    {
        foreach (var plane in planeManager.trackables)
            plane.gameObject.SetActive(value);
    }
}
