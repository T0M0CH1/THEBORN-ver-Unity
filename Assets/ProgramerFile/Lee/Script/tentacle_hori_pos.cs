using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacle_hori_pos : MonoBehaviour
{
    Vector3 Cam_pos;
    Vector3 pos;

    [HideInInspector]
    public static Vector3 Global_pos;


    // Update is called once per frame
    void Update()
    {
        Cam_pos = Camera.main.transform.position;
        pos.x = -10.0f + Cam_pos.x;
        pos.y = -4.0f + Cam_pos.y;
        transform.position = pos;
        Global_pos = transform.position;
    }
}
