using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Iwasaki : MonoBehaviour
{
    public float speed;

    //プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    public static bool halfwayBool;
    [SerializeField]
    private GameObject halfwayPoint;

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if (halfwayBool)
        {
            gameObject.transform.position = new Vector2(halfwayPoint.transform.position.x, -2.67f);
        }
    }

    void Update()
    {
        //if (halfwayBool && Input.GetKeyDown(KeyCode.F))
        //{
        //    gameObject.transform.position = new Vector2(halfwayPoint.transform.position.x, -2.67f);
        //}
        //キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;
        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(-0.12f, 0.12f, 0.12f);
            //anim.SetBool("walk", true);
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);
            //anim.SetBool("walk", true);
            xSpeed = -speed;
        }
        else
        {
            //anim.SetBool("walk", false);
            xSpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("GameOver");
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HalfwayPoint")
        {
            halfwayBool = true;
        }
    }
}
