using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARController : MonoBehaviour
{
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private bool isAdded;

    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && !isAdded && CatSelectMenu.Instance.isSelected)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;
                    //Instantiate(cubePrefab, hitPose.position, hitPose.rotation);
                    Instantiate(CatSelectMenu.Instance.selectedVehicle, hitPose.position, hitPose.rotation);
                    isAdded = true;
                }
            }
        }
    }
}