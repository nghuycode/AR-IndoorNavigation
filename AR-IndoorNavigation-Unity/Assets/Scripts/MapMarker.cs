using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMarker : MonoBehaviour
{
    public GameObject PlayerView;
    public View View;
    public List<Marker> MarkerList = new List<Marker>();

    public void OnMarkerFound(string markerName) {
        View.ActivateMapView();

        int id = int.Parse(markerName);
        PlayerView.transform.position = MarkerList[id].OriginalPosition;
    }
}
