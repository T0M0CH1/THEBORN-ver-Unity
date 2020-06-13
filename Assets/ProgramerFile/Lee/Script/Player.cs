using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Range(0.0f,10.0f)]
    private float Move_Speed = 10.0f; //移動速度

    [SerializeField, Range(0.0f, 10.0f)]
    private float Slow_Speed = 5.0f;


    [SerializeField, Range(0.0f, 10.0f)]
    private float Jump_Power = 5.0f; //ジャンプ力

    private Vector3 Move_Velocity; //移動方向
    private Vector2 Jump_Velocity; //ジャンプ方向

    private float hori; //Game_Pad 左スティックの右左を取得
    private float vert; //Game_Pad 左スティックの上下を取得

    private Rigidbody2D rb;
    private SpriteRenderer renderer;
    private Animator animator;

    public bool SW_Light = false;
    private bool is_Jumping = true;
    private bool is_Grounding = false; //キャラの着地判定

    //------------------------------------------------------------------

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //joystick button 0 ＝ Button_A
        if (Input.GetKeyDown("joystick button 0") && is_Grounding)
        {
            is_Jumping = true;
        }

        //joystick button 0 ＝ Button_B
        if (Input.GetKeyDown("joystick button 1"))
        {
            //SW_Light = !SW_Light;
            Light_ON_OFF();
        }

        //joystick button 3 = Button_Y
        if (Input.GetKeyDown("joystick button 3"))
        {
            Item_Use();
        }

    }

    void FixedUpdate()
    {
        P_Moving();
        Jump();
    }

    void LateUpdate()
    {
        SetAnimator();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            is_Grounding = true;
        }
    }

    //------------------------------------------------------------------
    //------------------------------------------------------------------

    /// <summary>
    ///キャラの動く処理 
    /// </summary>
    void P_Moving()
    {
        hori = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        Move_Velocity = Vector3.zero;

        if (hori < 0)
        {
            Move_Velocity = new Vector3(hori,0,0);
            renderer.flipX = true; // renderer反転
        }

        else if (hori > 0)
        {
            Move_Velocity = new Vector3(hori, 0, 0);
            renderer.flipX = false;
        }

        transform.position += Move_Velocity * Move_Speed * Time.deltaTime;
    }

    /// <summary>
    /// 
    /// </summary>
    void Light_ON_OFF()
    {

        SW_Light = !SW_Light;
        if (SW_Light)
        {
            Debug.Log("ライトをつけた");
            Move_Speed -= Slow_Speed;
        }
        else
        {
           Debug.Log("ライトを切った");
            Move_Speed += Slow_Speed;
        } 
    }

    void Item_Use()
    {

    }

    /// <summary>
    /// キャラのジャンプ処理
    /// </summary>
    void Jump ()
    {
        if (!is_Jumping) return;
        rb.velocity = Vector2.zero;

        Jump_Velocity = new Vector2(0, Jump_Power);
        rb.AddForce(Jump_Velocity, ForceMode2D.Impulse);
        is_Grounding = false;
        is_Jumping = false;
    }

    void SetAnimator()
    {
        animator.SetBool("is_Grounding", is_Grounding);
        animator.SetFloat("Move_Velocity", Move_Velocity.x);
    }
}
