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
    private GameObject player;
    private bool dropBool;
    void Start()
    {
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.O) && player.transform.Find("Umbrella").gameObject.activeSelf == false)
        //{
        //    Debug.Log("sasitenai");
        //}
        //else if (Input.GetKeyDown(KeyCode.P) && player.transform.Find("Umbrella").gameObject.activeSelf == true)
        //{
        //    Debug.Log("sasitenru");
        //}
        if (dropBool)
        {         
            if (Player.enemyBool == false)
            {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - 0.005f, this.gameObject.transform.position.y - 0.01f, -5);
            }
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 0.01f, -5);
        }
        //虫が地面に落下したら
        if (onGroundBool)
        {
            dropBool = false;
            Player.enemyBool = true;
            onGroundBool = false;
            this.gameObject.SetActive(false);
            GameObject obj = (GameObject)Resources.Load("GroundEnemy");
            GameObject instance = (GameObject)Instantiate(obj,new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -5f),Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            animator.Play("Shrink");
            StartCoroutine(WaitTime(1.8f));
        }

        if(player.transform.Find("Umbrella").gameObject.activeSelf == true)
        {
            Player.enemyBool = false;
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
            this.rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            dropBool = true;
        }
        else if(collision.gameObject.tag == "Player" && player.transform.localScale.x == -1)
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
