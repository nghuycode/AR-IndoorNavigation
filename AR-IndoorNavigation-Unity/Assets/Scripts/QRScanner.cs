using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRScanner : MonoBehaviour
{
    public MapMarker MapMarker;
    public QRCodeDecodeController qrController;
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
        MapMarker.LoadPOI(data);
        View.Instance.ActivateARView();
    }
}
