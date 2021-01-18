using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GrassSpawner : MonoBehaviour
{
    public static GrassSpawner Instance;
    public GameObject[] Grass;
    public ARPlaneManager ARPM;
    public GameObject Indicator;
    public Vector3 offset;
    public float borderL, borderR, borderU, borderD;

    private void Awake()
    {
        Instance = this;
        InvokeRepeating("SpawnAroundIndicator", 0f, 5f);
    }
    private void Update()
    {

    }
    public void SpawnAroundIndicator()
    {
        Vector3 indicatorPos = Indicator.transform.position;
        GrassSpawner.Instance.DestroyAll();
        //Spawn grass around the indicator
        for (float i = -5; i < 5; i++)
        {
            var newPosL = new Vector3(indicatorPos.x - offset.x, indicatorPos.y - 2, i);
            var newPosR = new Vector3(indicatorPos.x + offset.x, indicatorPos.y - 2, i);
            Spawn(newPosL);
            Spawn(newPosR);
        }
        if (!Indicator.GetComponent<PlacementIndicator>().CanIndicate)
            return;
    }
    public void DestroyAll()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void Spawn(Vector3 pos)
    {
        //Debug.Log("Spawned");
        //GameObject newGrass = Instantiate(Grass[Random.Range(0, Grass.Length)], Vector3.zero, Quaternion.identity, this.transform);
        //newGrass.transform.position = pos;
    }
}
