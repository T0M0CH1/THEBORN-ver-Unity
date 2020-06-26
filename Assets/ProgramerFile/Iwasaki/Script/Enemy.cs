using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;    
    private bool onGroundBool;
    [SerializeField]
    private Collider2D perceptionPlayer;
    [SerializeField]
    private GameObject player;
    void Start()
    {
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {    
        //虫が地面に落下したら
        if (onGroundBool)
        {
            onGroundBool = false;
            this.gameObject.SetActive(false);
            GameObject obj = (GameObject)Resources.Load("GroundEnemy");
            GameObject instance = (GameObject)Instantiate(obj,new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0.0f),Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            animator.Play("Shrink");
            StartCoroutine(WaitTime(1.8f));
        }
    }         

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.SetBool("toFind", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //フェイントで虫が落ちないようにする処理
        if (collision.gameObject.tag == "Player" && player.transform.localScale.x == 1)
        {            
            rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            animator.SetBool("toFind", false);
        }
    }

    IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
        perceptionPlayer.enabled = false;
        onGroundBool = true;
        yield break;
    }
}
