using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.IO;
public class MapMarker : MonoBehaviour
{
    public GameObject POIPrefab;
    public View View;
    public List<POI> POIList = new List<POI>();

    public void LoadPOI(string markerName)
    {
        //load data of all POI(s) in the json file
        string path = Application.persistentDataPath + "/data" + markerName + ".json";
        string jsonString = File.ReadAllText(path);
        Debug.Log(jsonString);
        var playerJson = JSON.Parse(jsonString);

        //SET VALUES
        for (int i = 0; i < this.transform.childCount; ++i) 
            GameObject.Destroy(this.transform.GetChild(i).gameObject);
        for (int i = 0; i < playerJson.AsArray.Count; ++i) {
            GameObject GOPC = Instantiate(POIPrefab, Vector3.zero, Quaternion.identity, this.transform);
            POIList.Add(GOPC.GetComponent<POI>());
            GOPC.GetComponent<POI>().LoadFromJSON(playerJson[i]["Name"], playerJson[i]["Pos"]);
        }
        var POIListGO = GameObject.Find("POIList");
        POIListGO.GetComponent<POIList>().UpdatePOIList();
    }
    public void SavePOI(string markerName) {
        Debug.Log(PlayerPrefs.GetInt("Map"));
        PlayerPrefs.SetInt("Map", PlayerPrefs.GetInt("Map") + 1);
        for (int i = 0; i < this.transform.childCount; ++i) 
            POIList.Add(this.transform.GetChild(i).GetComponent<POI>());
        //Save data of all POI(s) in the json file
        JSONNode node = new JSONArray();
        for (int i = 0; i < POIList.Count; ++i) {
            node.Add(POIList[i].SaveToJSON());
        }
        
        int id = PlayerPrefs.GetInt("Map");
        string path = Application.persistentDataPath + "/data" + id.ToString() + ".json";
        Debug.Log(path);
        File.WriteAllText(path, node.ToString());
    }
}
