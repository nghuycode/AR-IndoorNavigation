using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject CameraAR;
    public GameObject POIPrefab;
    public GameObject MapMarker;
    private void Update()
    {
        this.transform.localPosition = CameraAR.transform.position;
        TouchToSpawn();
    }
    private void TouchToSpawn()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Spawned POI");
            Debug.Log(Input.mousePosition);
            Vector3 realWorldPosPC = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(realWorldPosPC);
            GameObject GOPC = Instantiate(POIPrefab, realWorldPosPC, Quaternion.identity, this.transform.parent);
            GOPC.transform.SetParent(MapMarker.transform);
        }
    }
}
