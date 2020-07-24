using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    GameObject _player;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
       // _player = GameObject.Find("Player_Sample");
    }

    // Update is called once per frame
    void Update()
    {
        //pos = _player.transform.position;
        //transform.position = pos;
    }

    //private void OnTriggerEnter2D(Collider2D coll)
    //{
    //   if(coll.gameObject.tag == "Boss")
    //   {
    //   }
    //}
}
