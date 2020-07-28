using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_replica : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    Sprite[] sprite;
    SpriteRenderer spriteRenderer;

    Vector3 pos;
    
    public static bool is_sprite_Change;

    public static int HP;

    float speed = 1.0f;
    float amout = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        HP = 3;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(is_sprite_Change)
        {
            StartCoroutine(sprite_change());
            is_sprite_Change = false;
        }
        //transform.position = Camera.main.ScreenToWorldPoint(new Vector3(960.0f, 800.0f , 10.0f));
        pos = transform.position;
        pos.x = player.transform.position.x;
        pos.y = 1.8f;
        transform.position = pos;
    }

    private IEnumerator sprite_change()
    {
        spriteRenderer.sprite = sprite[1];
        yield return new WaitForSeconds(2.0f);
        spriteRenderer.sprite = sprite[0];
    }
}
