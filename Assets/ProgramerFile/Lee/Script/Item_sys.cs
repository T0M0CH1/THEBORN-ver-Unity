using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_sys : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private GameObject Item_Menu;

    [SerializeField]
    private Image[] Item; //Item選択画面

    [SerializeField]
    private Image Item_img; 

    //---------------------------------------------------
    [SerializeField]
    private Image[] Item_icon; //Item_Icon(Image)

    [SerializeField]
    private Image[] img_Skill;// CoolDown確認UI

    [SerializeField]
    private Image img_Item_Hending; // アイテム装備中UI
    //---------------------------------------------------

    [SerializeField]
    private GameObject item_sys;

    [Header("アイテム選択中のスピード"),SerializeField, Range(0.0f, 1.0f)]
    private float Game_Speed = 1.0f;

    [Header("アイテム再使用時間"),SerializeField, Range(0.0f, 5.0f)]
    private float cool = 5.0f; // Cool Down

    [SerializeField]
    private Image centeIcon;

    //-------------------------------------------------
    [Header("アイテム参考リスト"),SerializeField]
    private GameObject _umbrella;
    [SerializeField]
    private GameObject _wachingBar;

    //-------------------------------------------------

    private int Item_num; //Item 選択判定
    private bool[] Item_flag; //Item Cool Down 判定する変数

    //intput
    private float Rsh; // Game_Pad 右スティックの右左を取得
    private float Rsv; // Game_Pad 右スティックの上下を取得


    public static bool end_Washing; 
    //------------------------------------------------------------------

    void Awake()
    {
        Item_flag_init();
        Item_Menu.SetActive(false);
    }

    void Update()
    {
        //switch (Item_num)
        //{
        //    case 1:
        //        centeIcon.GetComponent<Image>().sprite = Item_icon[Item_num].GetComponent<Image>().sprite;
        //        break;
        //    case 2:
        //        centeIcon.GetComponent<Image>().sprite = Item_icon[Item_num].GetComponent<Image>().sprite;
        //        break;
        //    case 3:
        //        centeIcon.GetComponent<Image>().sprite = Item_icon[Item_num].GetComponent<Image>().sprite;
        //        break;
        //    case 4:
        //        centeIcon.GetComponent<Image>().sprite = Item_icon[Item_num].GetComponent<Image>().sprite;
        //        break;
        //    case 5:
        //        centeIcon.GetComponent<Image>().sprite = Item_icon[Item_num].GetComponent<Image>().sprite;
        //        break;
        //}
        Rsh = Input.GetAxis("R_Stick_H"); // Game_Pad 右スティックの右左を取得
        Rsv = Input.GetAxis("R_Stick_V"); // Game_Pad 右スティックの上下を取得

        if (Input.GetKey("joystick button 5")) //Button_R_B
        {
            Item_Menu.SetActive(true);
            Time.timeScale = Game_Speed;

            if ((Rsh != 0) || (Rsv != 0))
            {
                Item_Select(GetAngle(Rsh, Rsv));
            }

            Item_img.sprite = Item_icon[Item_num].sprite;
        }

        if (Input.GetKeyUp("joystick button 5")) //Button_R_B
        {
            Item_Menu.SetActive(false);
            Time.timeScale = 1; //普通のスピード
            img_Item_Hending.GetComponent<Image>().sprite = Item_icon[Item_num].GetComponent<Image>().sprite;
        }

        if (Input.GetKeyDown("joystick button 3") && Item_flag[Item_num]) //Button_R_Y
        {
            Item_use(Item_num);
        }
    }

    //---------------------------------------------------------
    //---------------------------------------------------------

    /// <summary>
    /// 角度を取得(0 ~ 360)
    /// </summary>
    /// <param name="x">X_Pos</param>
    /// <param name="y">Y_Pos</param>
    /// <returns>角度</returns>
    private float GetAngle(float x, float y)
    {
        float degrees = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        degrees = (degrees + 360) % 360;
        return degrees;
    }


    /// <summary>
    /// 角度によってItem選択
    /// </summary>
    /// <param name="degrees">角度入力</param>
    private void Item_Select(float degrees)
    {
        for (int i = 0; i < Item.Length; i++)
        {
            Item[i].color = Color.white;
        }

        if (degrees <= 90)
        {
            Item[0].color = Color.gray;
            Item_num = 0;
        }

        else if (degrees <= 180)
        {
            Item[1].color = Color.gray;
            Item_num = 1;
        }

        else if (degrees <= 270)
        {
            Item[2].color = Color.gray;
            Item_num = 2;
        }

        else if (degrees <= 360)
        {
            Item[3].color = Color.gray;
            Item_num = 3;
        }

        //else if (degrees <= 360)
        //{
        //    Item[4].color = Color.gray;
        //    Item_num = 4;
        //}

    }

    /// <summary>
    /// アイテム処理
    /// </summary>
    /// <param name="Item_num">Itam list</param>
    public void Item_use(int Item_num)
    {
        switch (Item_num)
        {
           
            //傘関連処理
            case 0:
                I_active.Set_Item(_umbrella, true);
                StartCoroutine(CoolTime(Item_num, cool));
                StartCoroutine(I_active.duration(_umbrella, 5.0f));
                Debug.Log("use =" + Item_num);
            
            break;

            //ハンカチ連処理
            case 1:

                if (Player.useable_Hanky)
                {
                    _wachingBar.SetActive(true);
                    //StartCoroutine(CoolTime(Item_num, cool));
                    WachingBar.is_Washing = true; // 鏡を洗い開始
                }
                //------
                else
                {
                    Debug.Log("鏡がいないです");
                }
                //------
                break;
            case 2:

                //香水処理
                if(Player.useable_homesickness)
                {
                    StartCoroutine(CoolTime(Item_num, cool));
                    Player.moveable = true;
                    Destroy(Player.Enemy_bug_obj, 1.0f);
                }

                else
                {
                    Debug.Log("敵がいない");
                }


                break;
            case 3:
                StartCoroutine(CoolTime(Item_num, cool));
                Debug.Log("use =" + Item_num);
                break;
            //case 4:
            //    StartCoroutine(CoolTime(Item_num, cool));
            //    Debug.Log("use =" + Item_num);
            //    break;
            default:
                break;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    private void Item_flag_init()
    {
        Item_flag = new bool[Item.Length];

        for (int i = 0; i < Item.Length; i++)
        {
            Item_flag[i] = true;
        }
    }

    /// <summary>
    /// cool_down System
    /// </summary>
    /// <param name="Item_num">Items List</param>
    /// <param name="cool">Cool Down</param>
    /// <returns></returns>
    IEnumerator CoolTime(int Item_num, float cool)
    {
        if (!Item_flag[Item_num]) yield break;

        Item_flag[Item_num] = false;
        Debug.Log("Start" + Item_flag[Item_num]);
        while (cool > 1.0f)
        {
            cool -= Time.deltaTime;

            img_Skill[Item_num].GetComponent<Image>().fillAmount = (1.0f / cool);
            yield return new WaitForFixedUpdate();
        }

        Item_flag[Item_num] = true;
        Debug.Log("End" + Item_flag[Item_num]);
    }

}
