﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramanager : MonoBehaviour
{

    //プレイヤーを格納する変数
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //カメラとプレイヤーの位置を同じにする
        transform.position = new Vector3(player.transform.position.x, 0, -10);

        if(transform.position.x < 0)
        {
            transform.position = new Vector3(0, 0, -10);
        }

        if (transform.position.x >= 18)
        {
            transform.position = new Vector3(18, 0, -10);

        }

    }
}

