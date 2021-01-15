using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public static View Instance;
    public GameObject ARView, QRView, MapMarker;
    public QRScanner QRScanner;

    private void Awake() {
        Instance = this;
    }
    public void ActivateARView()
    {
        ResetView();
        ARView.SetActive(true);
    }
    public void ActivateQRView() {
        ResetView();
        for (int i = 0; i < MapMarker.transform.childCount; ++i) {
            GameObject.Destroy(MapMarker.transform.GetChild(i).gameObject);
        }
        QRView.SetActive(true);
        QRScanner.StartScan();
    }
    public void Reset()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    void ResetView() {
        ARView.SetActive(false);
        QRView.SetActive(false);
    }
}
