using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class umbrella :MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enermy")
        {
            
        }
    }
}
