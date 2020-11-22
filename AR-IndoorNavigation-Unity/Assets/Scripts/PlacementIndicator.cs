using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    public bool CanIndicate;
    private ARRaycastManager raycastManager;
    private GameObject visual;

    private void Start() {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;
        visual.SetActive(false);
    }
    private void Update() {
        GameObject[] Planes = GameObject.FindGameObjectsWithTag("ARPlane");
        if (Planes.Length > 0) {
            CanIndicate = true;
        }
        else {
            CanIndicate = false;
            visual.SetActive(false);
            GameObject GO = GameObject.FindGameObjectWithTag("Portal");
            //GameObject.Destroy(GO);
        }
        if (CanIndicate) {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

            if (hits.Count > 0) {
                transform.position = hits[0].pose.position;
                transform.rotation = hits[0].pose.rotation;

                if (!visual.activeInHierarchy) {
                    visual.SetActive(true);
                }
            }
        }
    }
}
