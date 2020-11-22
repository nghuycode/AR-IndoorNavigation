using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.IO;
public class MapMarker : MonoBehaviour
{
    public View View;
    public List<POI> POIList = new List<POI>();

    public void LoadPOI(string markerName)
    {
        //load data of all POI(s) in the json file
    }
    public void SavePOI(string markerName) {
        for (int i = 0; i < this.transform.childCount; ++i) 
            POIList.Add(this.transform.GetChild(i).GetComponent<POI>());
        //Save data of all POI(s) in the json file
        JSONNode node = new JSONArray();
        for (int i = 0; i < POIList.Count; ++i) {
            node.Add(POIList[i].SaveToJSON());
        }
        Debug.Log(node.ToString());
        
        string path = Application.persistentDataPath + "/data.json";
        Debug.Log(path);
        File.WriteAllText(path, node.ToString());
    }
}
