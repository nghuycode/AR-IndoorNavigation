using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public Dropdown ViewDropdown;
    public GameObject ARView, QRView, MapView;
    public QRScanner QRScanner;

    private void Start() {
        ViewDropdown.onValueChanged.AddListener(OnViewChange);
    }
    public void OnViewChange(int num) {
        num = ViewDropdown.value;
        switch (num) {
            case 0: 
                ActivateARView();
                break;
            case 1:
                ActivateQRView();
                break;
            case 2:
                ActivateMapView();
                break;
        }
    }
    public void ActivateARView() {
        ResetView();
        MapView.SetActive(true);
        ARView.SetActive(true);
    }
    public void ActivateQRView() {
        ResetView();
        QRView.SetActive(true);
        QRScanner.StartScan();
    }
    public void ActivateMapView() {
        ResetView();
        MapView.SetActive(true);
        ARView.SetActive(true);
    }
    void ResetView() {
        ARView.SetActive(false);
        MapView.SetActive(false);
        QRView.SetActive(false);
    }
}
