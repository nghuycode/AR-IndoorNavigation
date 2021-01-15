using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QRScanner : MonoBehaviour
{
    public MapMarker MapMarker;
    public QRCodeDecodeController qrController;
    public Text Log;
    private void Start() {
        qrController.onQRScanFinished += onScanFinished;
    }
    public void StartScan() {
        this.qrController.Reset();
		if (this.qrController != null)
		{
			this.qrController.StartWork();
		}
    }
    public void onScanFinished(string data) {
        Log.text = data.ToString();
        MapMarker.LoadPOI(data);
        View.Instance.ActivateARView();
    }
}
