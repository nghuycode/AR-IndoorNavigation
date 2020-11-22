using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARCamera : MonoBehaviour
{
    public Text Log;
    void Update()
    {
        Log.text = this.transform.position.ToString();
    }
}
