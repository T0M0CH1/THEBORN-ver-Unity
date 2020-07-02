using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, -0.63f, -10);

        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, -0.63f, -10);
        }

        if (transform.position.x >= 20.5f)
        {
            transform.position = new Vector3(20.5f, -0.63f, -10);
        }
    }
}
