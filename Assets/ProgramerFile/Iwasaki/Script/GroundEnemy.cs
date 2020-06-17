using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    private GameObject player;    
    private Vector2 perceptionPlayer;
    [SerializeField]
    private GameObject groundEnemy;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        perceptionPlayer = groundEnemy.GetComponent<BoxCollider2D>().size;
    }

    // Update is called once per frame
    void Update()
    {
        ////ライトがついていたら
        //if ()
        //{
        //    perceptionPlayer.x = 40;
        //    groundEnemy.GetComponent<BoxCollider2D>().size = perceptionPlayer;
        //}
        ////ライトが消えていたら
        //if ()
        //{
        //    perceptionPlayer.x = 20;
        //    groundEnemy.GetComponent<BoxCollider2D>().size = perceptionPlayer;
        //}
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.transform.position = Vector3.MoveTowards(transform.position, new Vector2(player.transform.position.x, -2.8f), Time.deltaTime);
            if (this.transform.position.x < player.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}
