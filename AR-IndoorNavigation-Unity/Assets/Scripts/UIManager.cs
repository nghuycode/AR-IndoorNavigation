using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject BG1, BG2;
    public void BackToBG1()
    {
        BG1.SetActive(true);
        BG2.SetActive(false);
    }
    public void GoToBG2()
    {
        BG1.SetActive(false);
        BG2.SetActive(true);
    }
}
