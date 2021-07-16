using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;
    public static bool isActive;
    public static GameObject spawnedObject;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;

        return false;
    }

    bool TouchCollideWithUI(Vector2 position)
    {
        UnityEngine.EventSystems.PointerEventData pointer = new UnityEngine.EventSystems.PointerEventData(UnityEngine.EventSystems.EventSystem.current);
        pointer.position = position;
        List<UnityEngine.EventSystems.RaycastResult> raycastResults = new List<UnityEngine.EventSystems.RaycastResult>();
        UnityEngine.EventSystems.EventSystem.current.RaycastAll(pointer, raycastResults);

        if (raycastResults.Count > 0)
        {
            return true;
        }

        return false;
    }


    void Update()
    {
        if (!isActive)
        {
            return;
        }

        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (TouchCollideWithUI(touchPosition))
            return;

        if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            Debug.Log(hitPose);

            if (spawnedObject == null && gameObjectToInstantiate != null)
            {
                Debug.Log("CREATE NEW OBJECT");
                spawnedObject = Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation);
            }
            else if (spawnedObject != null)
            {
                if (spawnedObject.activeSelf != true)
                {
                    spawnedObject.SetActive(true);
                }
                Debug.Log("MOVE OBJECT");
                spawnedObject.transform.position = hitPose.position;
            }
        }
    }
}
