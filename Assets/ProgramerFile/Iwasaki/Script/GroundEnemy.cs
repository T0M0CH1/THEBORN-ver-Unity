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
        //ライトが点いているときの虫の索敵範囲
        if (Player.SW_Light == false)
        {
            perceptionPlayer.x = 40;
            groundEnemy.GetComponent<BoxCollider2D>().size = perceptionPlayer;
        }
        //ライトが消えているときの虫の索敵範囲
        if (Player.SW_Light)
        {
            perceptionPlayer.x = 20;
            groundEnemy.GetComponent<BoxCollider2D>().size = perceptionPlayer;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //索敵範囲内にプレイヤーがいたら
        if(collision.gameObject.tag == "Player")
        {
            //プレイヤーを追いかける処理
            this.transform.position = Vector3.MoveTowards(transform.position, new Vector2(player.transform.position.x, -2.8f), Time.deltaTime);
            //左右反転処理
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
