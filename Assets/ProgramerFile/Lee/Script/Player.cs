using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField]
    //Item_sys item_sys;

    [SerializeField, Range(0.0f,10.0f)]
    private float Move_Speed = 10.0f; //移動速度

    [SerializeField, Range(0.0f, 10.0f)]
    private float Slow_Speed = 5.0f;

    [SerializeField, Range(0.0f, 10.0f)]
    private float Jump_Power = 5.0f; //ジャンプ＿力

    [SerializeField]
    private GameObject Hend_Light;

    private Vector3 Move_Velocity; //移動方向
    private Vector2 Jump_Velocity; //ジャンプ方向

    private float hori; //Game_Pad 左スティックの右左を取得
    private float vert; //Game_Pad 左スティックの上下を取得

    private Rigidbody2D rb;
    private SpriteRenderer renderer;
    private Animator animator;

    //アニメーション（モーション）切り替える変数
    //------------------------------------------------------------------
    private bool SW_Light = false;
    private bool Quest = false;
    private bool Light = false;
    private bool is_Grounding = false; //キャラの着地判定
    //------------------------------------------------------------------
                  
    private bool is_Jumping = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //item_sys = GetComponent<Item_sys>();
    }

    void Update()
    {
        //joystick button 0 ＝ Button_A
        if (Input.GetKeyDown("joystick button 0") && is_Grounding) //ジャンプ
        {
            is_Jumping = true;
        }

        //joystick button 0 ＝ Button_B
        if (Input.GetKeyDown("joystick button 1")) //ライト
        {
            //SW_Light = !SW_Light;
            Light_ON_OFF();
        }

        //joystick button 2 ＝ Button_X
        if (Input.GetKey("joystick button 2")) //探索
        {
            Quest = true;
            //探索できるオブジェクト判定を追加必要（ray Cast）
            Debug.Log("探索している");
        }

        if (Input.GetKeyUp("joystick button 2")) //探索
        {
            Quest = false;         
        }

        //joystick button 3 = Button_Y
        //if (Input.GetKeyDown("joystick button 3"))
        //{
        //}

    }

    void FixedUpdate()
    {
        P_Moving();
        Jump();
    }

    void LateUpdate()
    {
        initAnimator();
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
            transform.localScale = new Vector3(-1, 1, 1);
            //renderer.flipX = true; // renderer反転
        }

        else if (hori > 0)
        {
            Move_Velocity = new Vector3(hori, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
            //renderer.flipX = false;
        }

        transform.position += Move_Velocity * Move_Speed * Time.deltaTime;
    }

    /// <summary>
    /// ライト処理
    /// </summary>
    void Light_ON_OFF()
    {

        if (SW_Light)
        {
           //Debug.Log("ライトを切った");
            Hend_Light.SetActive(false);
            Move_Speed -= Slow_Speed;
        }
        else
        {
            //Debug.Log("ライトをつける");
            Hend_Light.SetActive(true);
            Move_Speed += Slow_Speed;
        }
        SW_Light = !SW_Light;
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

    /// <summary>
    /// アニメーション専用変数更新
    /// </summary>
    void initAnimator()
    {
        animator.SetBool("is_Grounding", is_Grounding);
        animator.SetBool("Quest", Quest);
        animator.SetBool("Light", Light);
        animator.SetFloat("Move_Velocity", Move_Velocity.x);
    }
}
