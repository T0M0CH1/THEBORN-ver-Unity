﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bug : MonoBehaviour
{
    static public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Player.moveable = false;
        }
    }
   
}
