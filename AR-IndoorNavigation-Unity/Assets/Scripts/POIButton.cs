using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class POIButton : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnBtnClick);
    }
    private void OnBtnClick()
    {
        Debug.Log("cc");
        POIList.Instance.POIChooseByBtn(this.transform.GetChild(0).GetComponent<Text>().text);
    }
}
