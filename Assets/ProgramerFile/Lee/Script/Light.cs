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
       _player = GameObject.Find("Player_Sample");
        pos.x = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_player.transform.position.x + pos.x * _player.transform.localScale.x,
                                        _player.transform.position.y,
                                        _player.transform.position.z);
        transform.localScale = _player.transform.localScale;
    }

    //private void OnTriggerEnter2D(Collider2D coll)
    //{
    //   if(coll.gameObject.tag == "Boss")
    //   {
    //   }
    //}
}
