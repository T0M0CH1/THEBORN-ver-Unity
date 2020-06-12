using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Sprite[] enemyImage;
    private Rigidbody2D rb2D;
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = enemyImage[0];
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //オブジェクトから下側にRayを伸ばす
        Ray2D ray = new Ray2D(transform.position, Vector2.down);

        int layerMask = LayerMask.GetMask(new string[] { "Player" });
        int raydistance = 10;

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10f, layerMask);
        Debug.DrawRay(ray.origin, ray.direction * raydistance, Color.red);
        if (hit.collider)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enemyImage[1];
            rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }                
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            this.gameObject.transform.localScale = new Vector3(0.35f, 0.15f, 0);
            StartCoroutine(waitTime(0.5f));
        }
    }

    IEnumerator waitTime(float time)
    {
        new WaitForSeconds(time);
        yield break;
    }
}
