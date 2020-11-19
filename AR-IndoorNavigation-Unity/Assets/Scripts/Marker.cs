using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public string Name;
    public int ID;
    public Vector3 OriginalPosition;
    private void Awake() {
        Name = this.gameObject.name;
        OriginalPosition = this.transform.position;
    }
}
