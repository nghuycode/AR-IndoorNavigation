using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class POI : MonoBehaviour {
    public string Name;
    public Vector3 OffsetPos;
    public Text UIName;
    private void OnEnable() {
        OffsetPos = this.transform.localPosition;
        Name = this.gameObject.name;
        
        ApplyName();
    }
    public JSONNode SaveToJSON() {
        JSONNode node = new JSONObject();
        node["Name"] = Name;
        node["Pos"] = OffsetPos;
        return node;
    }
    public void ApplyName() {
        UIName.text = Name;
    }
}
