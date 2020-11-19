using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public Dropdown ViewDropdown;
    public GameObject ARView, QRView, MapView;

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
        ARView.SetActive(true);
        MapView.SetActive(true);
    }
    public void ActivateQRView() {
        ResetView();
        QRView.SetActive(true);
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
