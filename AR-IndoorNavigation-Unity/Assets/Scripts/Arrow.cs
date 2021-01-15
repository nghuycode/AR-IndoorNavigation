using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform Target;
    public Transform Cam;
    public Vector3 offset;
    RectTransform rt;
    private void Start() {
        rt = GetComponent<RectTransform>();
    }
    private void Update() {
        //this.transform.position = Cam.transform.position + offset;
        // if (Target != null)
        //     this.transform.LookAt(Target.transform);

        if (Target) {
            // Get the position of the object in screen space
            Vector3 objScreenPos = Camera.main.WorldToScreenPoint(Target.transform.position);

            // Get the directional vector between your arrow and the object
            Vector3 dir = (objScreenPos - rt.position).normalized;

            float angle = Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x);


            rt.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
