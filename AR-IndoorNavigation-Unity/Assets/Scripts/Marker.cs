using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public string Name;
    public int ID;
    public Vector3 OriginalPosition, OriginalRotation;
    private void Awake()
    {
        Name = this.gameObject.name;
        OriginalPosition = this.transform.localPosition;
        OriginalRotation = this.transform.localEulerAngles;
    }
}
