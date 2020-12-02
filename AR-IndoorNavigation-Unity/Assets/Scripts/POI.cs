using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleJSON;

public class POI : MonoBehaviour {
    public Canvas Canvas;
    public TMP_InputField InputField;
    private void OnEnable() {
        Canvas.worldCamera = Camera.main;
    }
    public JSONNode SaveToJSON() {
        JSONNode node = new JSONObject();
        node["Name"] = InputField.text;
        node["Pos"] = this.transform.localPosition;
        return node;
    }
    public void LoadFromJSON(string name, Vector3 newPos) {
        InputField.text = name;
        this.transform.localPosition = newPos;
    }
}
