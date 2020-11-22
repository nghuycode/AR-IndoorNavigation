using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMap : MonoBehaviour
{
    public GameObject Player;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Player.transform.position.x, this.transform.position.y, Player.transform.position.z);
        this.transform.eulerAngles = new Vector3(90, 0, Player.transform.eulerAngles.x);
    }
}
