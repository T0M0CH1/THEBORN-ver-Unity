using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacle_effect_hori : MonoBehaviour
{

    Rigidbody2D rb;
    float speed = 25.0f;
    float displayer_witch = 1920.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }

    void Update()
    {
        Vector3 view = Camera.main.WorldToScreenPoint(transform.position);
        if (view.x > displayer_witch)
        {
            Destroy(gameObject, 2.0f);
        }
    }
}
