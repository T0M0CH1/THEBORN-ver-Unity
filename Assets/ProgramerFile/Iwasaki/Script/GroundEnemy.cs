using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundEnemy : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private float EnemySpeed = 1;


    private Vector2 perceptionFront;
    private Vector2 perceptionBehind;
    private Vector2 frontPos;
    private Vector2 behindPos;

    [SerializeField]
    private BoxCollider2D frontCollider;
    [SerializeField]
    private BoxCollider2D behindCollider;
    private float offsetBehind;
    private float offsetFront;

    [SerializeField]
    private float OFF_Perception;
    [SerializeField]
    private float ON_Perception;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        //コライダーの大きさ初期化
        perceptionBehind = behindCollider.GetComponent<BoxCollider2D>().size;
        perceptionFront = frontCollider.GetComponent<BoxCollider2D>().size;
        //コライダーの位置初期化
        behindPos = behindCollider.GetComponent<BoxCollider2D>().offset;
        frontPos = frontCollider.GetComponent<BoxCollider2D>().offset;
    }

    // Update is called once per frame
    void Update()
    {
        //ライトが点いているときの虫の索敵範囲
        if (Player.SW_Light == false)
        {
            //後ろ側のコライダーの調整
            perceptionBehind.x = OFF_Perception;
            behindCollider.size = new Vector2(perceptionBehind.x, perceptionBehind.y);
            behindCollider.offset = new Vector2(MathRangeBehind(perceptionBehind.x), behindPos.y);
            //前側のコライダーの調整
            perceptionFront.x = OFF_Perception;
            frontCollider.size = new Vector2(perceptionFront.x, perceptionFront.y);
            frontCollider.offset = new Vector2(MathRangeFront(perceptionFront.x), frontPos.y);
        }
        //ライトが消えているときの虫の索敵範囲
        if (Player.SW_Light)
        {
            //後ろ側のコライダーの調整
            perceptionBehind.x = ON_Perception;            
            behindCollider.size = new Vector2(perceptionBehind.x, perceptionBehind.y);
            behindCollider.offset = new Vector2(MathRangeBehind(perceptionBehind.x), behindPos.y);
            //前側のコライダーの調整
            perceptionFront.x = ON_Perception;
            frontCollider.size = new Vector2(perceptionFront.x, perceptionFront.y);
            frontCollider.offset = new Vector2(MathRangeFront(perceptionFront.x), frontPos.y);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //索敵範囲内にプレイヤーがいたら
        if(collision.gameObject.tag == "Player")
        {
            //プレイヤーを追いかける処理
            this.transform.position = Vector3.MoveTowards(transform.position, new Vector2(player.transform.position.x, -4.38f), Time.deltaTime * EnemySpeed);
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

    private float MathRangeBehind(float behind)
    {
        offsetBehind = ((behind / 0.5f) * 0.25f) + 9;        
        return offsetBehind;
    }
    private float MathRangeFront(float front)
    {
        offsetFront = ((front / 0.5f) * -0.25f) - 7;
        return offsetFront;
    }
}
