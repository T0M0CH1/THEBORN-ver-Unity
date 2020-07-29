using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yami_mushi : MonoBehaviour
{

    private GameObject player;
    [SerializeField]
    //private float EnemySpeed = 0.01f;
    private float distance;
    private bool damaged;
    private float move_vec;

    SpriteRenderer spriteRenderer;
    Color color;

    float alpha = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        damaged = false;

        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;

    }

    // Update is called once per frame
    void Update()
    {
        if(damaged)
        {
            StartCoroutine(destroy());
        }
    }

    void FixedUpdate()
    {
        if(damaged)
        {
            damage_move();
        }
        else
        {
            move();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().Move_Speed *= 0.2f;
            Player.Jumpable = false;
        }

        if (collision.gameObject.tag == "Light")
        {
            damaged = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().Move_Speed /= 0.2f;
            Player.Jumpable = true;
        }
  //if (collision.gameObject.tag == "Light")
  //      {
  //          damaged = false;
  //      }
      
    }

    private void move()
    {
        //distance = Vector3.Distance(player.transform.position, transform.position);
        distance = transform.position.x - player.transform.position.x ;
        //distance = Mathf.Abs(distance);

        if (distance < 8.0f && distance > 0 && !damaged)
        {
            move_vec = -1;
            //this.transform.position = Vector3.MoveTowards(transform.position, new Vector2(player.transform.position.x, 0.0f), Time.deltaTime * EnemySpeed);
            transform.position += new Vector3(Time.deltaTime * move_vec, 0, 0);

        }

        else if(distance > -8.0f && distance < 0 && !damaged)
        {
            move_vec = 1;
            //this.transform.position = Vector3.MoveTowards(transform.position, new Vector2(player.transform.position.x, 0.0f), Time.deltaTime * EnemySpeed);
            transform.position += new Vector3(Time.deltaTime * move_vec, 0, 0);

        }

        if (this.transform.position.x < player.transform.position.x && !damaged) transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (this.transform.position.x > player.transform.position.x && !damaged) this.transform.rotation = Quaternion.Euler(0, 180, 0);
        //Debug.Log(distance);
    }

    private void damage_move()
    {
        move_vec = 1;
        distance = transform.position.x - player.transform.position.x;
        //distance = Mathf.Abs(distance);

        transform.position += new Vector3(Time.deltaTime * move_vec,0,0);

        if (this.transform.position.x < player.transform.position.x) transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (this.transform.position.x > player.transform.position.x) this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    IEnumerator destroy()
    {
        color = spriteRenderer.color;

        while (color.a > 0)
        {
            yield return new WaitForSeconds(1.0f);
            color.a -= Time.deltaTime;
            spriteRenderer.color = color;
            //spriteRenderer.color -= new Color(0, 0, 0, Time.deltaTime);
        }

        Destroy(gameObject);
    }
}

    
