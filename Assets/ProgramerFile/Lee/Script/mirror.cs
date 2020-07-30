using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirror : MonoBehaviour
{
    public struct Img
    {
       public int dirty;
       public int appear;
       public int Damageed;
       public int cleen;
    }
    Img img = new Img();
    
    public int is_mirror_img;

    [SerializeField]
    Sprite[] sprite_img;
    
    SpriteRenderer spriteRenderer;

    public static bool mirror_change = false;
    // Start is called before the first frame update
    void Start()
    {
        //=================
        img.dirty = 0;
        img.appear = 1;
        img.Damageed = 2;
        img.cleen = 3;
        //==================
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite_img[img.dirty];
        is_mirror_img = img.dirty;
    }

    // Update is called once per frame
    void Update()
    {
        if(mirror_change && gameObject == Player.mirror_obj)
        {
            if (spriteRenderer.sprite == sprite_img[img.appear]) return;
            spriteRenderer.sprite = sprite_img[img.appear];
            mirror_change = false;

            is_mirror_img = img.appear;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Light" && spriteRenderer.sprite == sprite_img[img.appear])
        {
            spriteRenderer.sprite = sprite_img[img.Damageed];
            is_mirror_img = img.Damageed;

            Boss_replica.is_sprite_Change = true;
            Boss_replica.HP--;
            StartCoroutine(change_cleen_mirror());
        }
    }

    IEnumerator change_cleen_mirror()
    {
        yield return new WaitForSeconds(2.0f);
        spriteRenderer.sprite = sprite_img[img.cleen];
        is_mirror_img = img.cleen;
    }
}
