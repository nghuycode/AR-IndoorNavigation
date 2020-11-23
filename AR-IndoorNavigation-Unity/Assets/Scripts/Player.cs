﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool CanSpawn;
    public GameObject CameraAR;
    public GameObject POIPrefab;
    public GameObject MapMarker;
    public PlacementIndicator PlacementIndicator;
    public Text Log;
    private void Update()
    {
        this.transform.localPosition = CameraAR.transform.position;
        TouchToSpawn();
    }
    private void TouchToSpawn()
    {
        if (Input.touchCount > 0 && CanSpawn)
        {
            if (Input.GetTouch(0).tapCount == 2) {
                Debug.Log("Spawned POI");
                Vector3 realWorldPosPC = PlacementIndicator.transform.position; 
                GameObject GOPC = Instantiate(POIPrefab, Vector3.zero, Quaternion.identity);
                GOPC.transform.position = realWorldPosPC;
                GOPC.transform.SetParent(MapMarker.transform);
                Log.text = realWorldPosPC.ToString();
            }
        }
    }
}
