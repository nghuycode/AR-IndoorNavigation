using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class POIList : MonoBehaviour
{
    public static POIList Instance;
    public int currentValue = -1;
    public Arrow Arrow;
    public Dropdown UIPOIList;
    public InputField IPF;
    public List<POI> POIs = new List<POI>();
    public UIManager UIManager;
    
    private void Awake()
    {
        Instance = this;
    }

    public GameObject MapMarker, GridPOI;
    private void Start() {
        UpdatePOIList();
    }
    private void Update() {
        //UpdatePOIList();
        if (MapMarker.transform.childCount > 0) {
            var latestPOI = MapMarker.transform.GetChild(MapMarker.transform.childCount - 1).GetComponent<POI>();
            changeDDItemText(latestPOI.GetComponent<POI>().InputField.text, MapMarker.transform.childCount - 1);
            updateButtonName();
        }
    }
    void updateButtonName()
    {
        for (int i = 0; i < MapMarker.transform.childCount; ++i)
            GridPOI.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = MapMarker.transform.GetChild(i).GetComponent<POI>().InputField.text;
    }
    void changeDDItemText(string newText, int index)
    {
        if (index < UIPOIList.options.Count)
        {
            Dropdown.OptionData newItem = new Dropdown.OptionData(newText);
            UIPOIList.options.RemoveAt(index);
            UIPOIList.options.Insert(index, newItem);
        }
    }
    public void UpdatePOIList() 
    {
        if (currentValue != -1)
            UIPOIList.value = currentValue;
        else 
            UIPOIList.value = -1;   
        POIs = new List<POI>();
        var POINames = new List<string>();
        UIPOIList.ClearOptions();
        for (int i = 0; i < MapMarker.transform.childCount; ++i) 
        {
            POIs.Add(MapMarker.transform.GetChild(i).GetComponent<POI>());
            POINames.Add(POIs[i].GetComponent<POI>().InputField.text);
        }
        UIPOIList.AddOptions(POINames);
    }
    public void POIChoose() {
        for (int i = 0; i < POIs.Count; ++i)
            if (POIs[i].InputField.text == IPF.text)
            {
                Arrow.Target = POIs[i].transform;
                UIManager.GoToBG2();
                POIs[i].Enable();
                return;
            }
    }
    public void EnableAllPOI()
    {
        foreach (POI poi in POIs)
        {
            poi.Enable();
        }
    }
    public void DisableAllPOI()
    {
        foreach (POI poi in POIs)
        {
            poi.Disable();
        }
    }
    public void POIChooseByBtn(string name)
    {
        Debug.Log(name);
        for (int i = 0; i < POIs.Count; ++i)
            if (POIs[i].InputField.text == name)
            {
                Arrow.Target = POIs[i].transform;
                UIManager.GoToBG2();
                POIs[i].Enable();
                return;
            }
    }
}
