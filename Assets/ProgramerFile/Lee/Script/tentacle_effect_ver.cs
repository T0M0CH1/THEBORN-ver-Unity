using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacle_effect_ver : MonoBehaviour
{

    Rigidbody2D rb;
    float speed = 25.0f;
    float displayer_height = 1080.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    void Update()
    {
        Vector3 view = Camera.main.WorldToScreenPoint(transform.position);
        if (view.y > displayer_height)
        {
            Destroy(gameObject, 2.0f);
        }
    }
}

