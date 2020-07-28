using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirror : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprite_img;
    SpriteRenderer spriteRenderer;

    public static bool mirror_change = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite_img[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(mirror_change && gameObject == Player.mirror_obj)
        {
            spriteRenderer.sprite = sprite_img[1];
            mirror_change = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Light" && spriteRenderer.sprite == sprite_img[1])
        {
            spriteRenderer.sprite = sprite_img[2];
            Boss_replica.is_sprite_Change = true;
            Boss_replica.HP--;
        }
    }
}
