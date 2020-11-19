//using GoogleARCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QRDecode : MonoBehaviour
{
    public QRCodeDecodeController QRcontroller;
    public GUIStyle gStyle;

    void Start()
    {
        QRcontroller.onQRScanFinished += onScanFinished;
    }


    void onScanFinished(string str)
    {
        GameObject.Find("StartPoint").GetComponent<SaveStartPoint>().setPoint(str);
    }
}
