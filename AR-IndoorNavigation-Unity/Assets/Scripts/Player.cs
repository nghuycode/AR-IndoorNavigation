using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 offset, offsetRotation;

    public Camera MapCamera;
    public GameObject CameraAR;
    public GameObject MarkerPrefab;
    private void Update()
    {
        this.transform.localPosition = CameraAR.transform.position + offset;
        //this.transform.localEulerAngles = new Vector3(0, CameraAR.transform.eulerAngles.y + offsetRotation.y, 0);
        TouchToSpawn();
    }
    private void TouchToSpawn()
    {
        if (Input.touchCount == 1)
        {
            Debug.Log("cc");
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                GameObject GO = Instantiate(MarkerPrefab, this.transform.position, Quaternion.identity, this.transform.parent);
            }
            else
                return;
        }
    }
}
