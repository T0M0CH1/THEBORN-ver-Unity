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
        //オブジェクトから下側にRayを伸ばす
        //Ray2D ray = new Ray2D(transform.position, Vector2.down);

        //int layerMask = LayerMask.GetMask(new string[] { "Player" });
        //int raydistance = 10;

        //RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10f, layerMask);
        //Debug.DrawRay(ray.origin, ray.direction * raydistance, Color.red);
        //if (hit.collider)
        //
        //    animator.Play("Find");
        //    rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        //}
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
        if (collision.gameObject.tag == "Player" && player.transform.localScale.x == -0.12f)
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
