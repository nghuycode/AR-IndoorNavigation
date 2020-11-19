using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QRScanner : MonoBehaviour
{
    public MapMarker MapMarker;
    public Text Log;
    public QRCodeDecodeController qrController;
    private void Start() {
        qrController.onQRScanFinished += onScanFinished;

        onScanFinished("0");
    }
    public void onScanFinished(string data) {
        Log.text = data;
        MapMarker.OnMarkerFound(data);
    }
}
