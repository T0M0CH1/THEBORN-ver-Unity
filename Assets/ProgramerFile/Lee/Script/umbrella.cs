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

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Enermy")
        {

        }
    }
}
