using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public static View Instance;
    public Dropdown ViewDropdown;
    public GameObject ARView, QRView, MapMarker;
    public QRScanner QRScanner;

    private void Awake() {
        Instance = this;
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
        }
    }
    public void ActivateARView() {
        ResetView();
        ViewDropdown.value = 0;
        ARView.SetActive(true);
    }
    public void ActivateQRView() {
        ResetView();
        for (int i = 0; i < MapMarker.transform.childCount; ++i) {
            GameObject.Destroy(MapMarker.transform.GetChild(i).gameObject);
        }
        ViewDropdown.value = 1;
        QRView.SetActive(true);
        QRScanner.StartScan();
    }
    void ResetView() {
        ARView.SetActive(false);
        QRView.SetActive(false);
    }
}
