using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera MapCamera;
    public GameObject CameraAR;
    public GameObject MarkerPrefab;
    private void Update() {
        this.transform.localPosition = CameraAR.transform.position;
        TouchToSpawn();
    }
    private void TouchToSpawn() {
        if (Input.touchCount == 1) {
            Debug.Log("cc");
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                GameObject GO = Instantiate(MarkerPrefab, this.transform.position, Quaternion.identity, this.transform.parent);
            }
        }
        else
            return;
    }
}
