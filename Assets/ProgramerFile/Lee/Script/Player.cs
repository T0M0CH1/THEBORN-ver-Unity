using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private Vector3 P_Scals;

    //キャラ画像
    //[SerializeField]
    //private Sprite[] playerImages;    

    //アニメーション（モーション）切り替える変数
    //------------------------------------------------------------------
    [HideInInspector]
    public static bool SW_Light = false;
    private bool Quest = false;
    private bool Light = false;
    private bool is_Grounding = false; //キャラの着地判定
    //------------------------------------------------------------------
                  
    private bool is_Jumping = true;

    //iwasaki変数
    [HideInInspector]
    public static bool halfwayBool;
    [SerializeField]
    private GameObject halfwayPoint;

    void Awake()
    {
        if (halfwayBool)
        {
            gameObject.transform.position = new Vector2(halfwayPoint.transform.position.x, -2.67f);
        }
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        //StartCoroutine(Battery.duration(2.0f));
        is_Jumping = false;
        P_Scals = transform.localScale;

    }

    void Update()
    {
        if(is_Grounding == false)
        {
            //renderer.sprite = playerImages[3];
        }
        //joystick button 0 ＝ Button_A
        if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Space) && is_Grounding) //ジャンプ
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
        if (Input.GetKeyDown("joystick button 2")) //探索
        {
            Quest = true;
            //探索できるオブジェクト判定を追加必要（ray Cast）
            Debug.Log("探索している");
        }

        if (Input.GetKeyUp("joystick button 2")) //探索
        {
            Quest = false;
            Debug.Log("探索終わり");

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
        //iwasaki関数
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    //------------------------------------------------------------------
    //------------------------------------------------------------------

    /// <summary>
    ///キャラの動く処理 
    /// </summary>
    void P_Moving()
    {
        //renderer.sprite = playerImages[5];
        hori = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");        
        Move_Velocity = Vector3.zero;

        if (hori < 0)
        {
            //renderer.sprite = playerImages[1];
            Move_Velocity = new Vector3(hori, 0, 0);
            transform.localScale = new Vector3(-P_Scals.x, P_Scals.y, P_Scals.z);
            //renderer.flipX = true; // renderer反転
        }

        else if (hori > 0)
        {
            //renderer.sprite = playerImages[1];
            Move_Velocity = new Vector3(hori, 0, 0);            
            transform.localScale = new Vector3(P_Scals.x, P_Scals.y, P_Scals.z);
            //renderer.flipX = false;
        }

        if (Battery.is_charging) return; //充電中には移動不可
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
            StartCoroutine(Battery.decrease(Battery.decrease_speed)); //Battery.decrease_speed　= battery減らす。スピード
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
        if (Battery.is_charging) return; //充電中にはJump不可
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
    //iwasaki関数
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HalfwayPoint")
        {
            halfwayBool = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HalfwayPoint" && Quest)
        {
            Debug.Log(Battery.battery);
            //collision.GetComponent<BoxCollider2D>().enabled = false;
            //徐々にバッテリーを回復できるようにプログラミングする予定。
            StartCoroutine(Battery.charg(0.2f));
            //Battery.battery += 1;
        }
    }
}
