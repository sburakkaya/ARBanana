using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MoveToCenter : MonoBehaviour
{
    private ARRaycastManager arRaycastManager;
    private Button btn;

    private void Awake()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        btn = GameObject.Find("movecenterbtn").GetComponent<Button>();
        btn.onClick.AddListener(MoveToCenterPosition);
    }

    public void MoveToCenterPosition()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon);

        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
        }
    }
}