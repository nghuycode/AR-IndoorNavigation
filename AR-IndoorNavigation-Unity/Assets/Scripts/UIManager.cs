using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject BG1, BG2;
    public GameObject Cam;
    public GameObject Map2D;
    public void BackToBG1()
    {
        BG1.SetActive(true);
        BG2.SetActive(false);
        POIList.Instance.EnableAllPOI();
    }
    public void GoToBG2()
    {
        BG1.SetActive(false);
        BG2.SetActive(true);
        POIList.Instance.DisableAllPOI();
    }
    public void ToggleCam() {
        Cam.SetActive(!Cam.activeInHierarchy);
        Map2D.SetActive(!Cam.activeInHierarchy);
    }
    public void QRUI()
    {
        Cam.SetActive(false);
        Map2D.SetActive(true);
        BG1.SetActive(true);
    }
    public void QRMode()
    {
        BG1.SetActive(false);
        BG2.SetActive(false);
    }
}
