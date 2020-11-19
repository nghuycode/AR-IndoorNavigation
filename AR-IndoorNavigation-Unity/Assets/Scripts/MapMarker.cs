using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMarker : MonoBehaviour
{
    public View View;
    public List<Marker> MarkerList = new List<Marker>();

    public void OnMarkerFound(string markerName) {
        View.ActivateMapView();
        var Player = GameObject.Find("Player").GetComponent<Player>();
        int id = int.Parse(markerName);
        Player.offset = new Vector3(MarkerList[id].OriginalPosition.x, 0, MarkerList[id].OriginalPosition.z);
    }
}
