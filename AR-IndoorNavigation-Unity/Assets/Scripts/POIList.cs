using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class POIList : MonoBehaviour
{
    public int currentValue = -1;
    public Arrow Arrow;
    public Dropdown UIPOIList;
    public List<POI> POIs = new List<POI>();

    public GameObject MapMarker;
    private void Start() {
        UpdatePOIList();
    }
    private void Update() {
        //UpdatePOIList();
        if (MapMarker.transform.childCount > 0) {
            var latestPOI = MapMarker.transform.GetChild(MapMarker.transform.childCount - 1).GetComponent<POI>();
            changeDDItemText(latestPOI.GetComponent<POI>().InputField.text, MapMarker.transform.childCount - 1);
        }
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
        Debug.Log(POIs[UIPOIList.value].name);
        Arrow.Target = POIs[UIPOIList.value].transform;
    }
}
