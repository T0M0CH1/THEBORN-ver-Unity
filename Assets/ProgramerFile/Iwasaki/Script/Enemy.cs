using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;
    [SerializeField]
    private GameObject player;
    private bool onGroundBool;
    [SerializeField]
    private Collider2D perceptionPlayer;
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
            this.transform.position = Vector3.MoveTowards(transform.position, new Vector2(player.transform.position.x, -2.8f), Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            animator.Play("Shrink");
            onGroundBool = true;
        }
    }         

    IEnumerator waitTime(float time)
    {
        new WaitForSeconds(time);
        yield break;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.Play("Find");            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {            
            rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
