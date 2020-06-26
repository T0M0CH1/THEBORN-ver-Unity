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
    private Image[] img_Skill;// CoolDown確認UI

    [SerializeField]
    private Image img_Item_Hending; // アイテム装備中UI

    [SerializeField]
    private GameObject item_sys;

    [Header("アイテム選択中のスピード"),SerializeField, Range(0.0f, 1.0f)]
    private float Game_Speed = 1.0f;

    [Header("アイテム再使用時間"),SerializeField, Range(0.0f, 5.0f)]
    private float cool = 5.0f; // Cool Down

    //-------------------------------------------------
    [Header("アイテム参考リスト"),SerializeField]
    GameObject _umbrella;
    //[SerializeField]
    //GameObject _item1;
    //[SerializeField]
    //GameObject _item2;
    //[SerializeField]
    //GameObject _item3;
    //[SerializeField]
    //GameObject _item4;
    //[SerializeField]
    //GameObject _item5;
    //-------------------------------------------------

    private int Item_num; //Item 選択判定
    private bool[] Item_flag; //Item Cool Down 判定する変数

    //intput
    private float Rsh; // Game_Pad 右スティックの右左を取得
    private float Rsv; // Game_Pad 右スティックの上下を取得

    //------------------------------------------------------------------

    void Awake()
    {
        Item_flag_init();
        Item_Menu.SetActive(false);
    }

    void Update()
    {
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
           
        }

        if (Input.GetKeyUp("joystick button 5")) //Button_R_B
        {
            Item_Menu.SetActive(false);
            Time.timeScale = 1; //普通のスピード
            img_Item_Hending.GetComponent<Image>().sprite = Item[Item_num].GetComponent<Image>().sprite;
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
        for (int i = 0; i < 6; i++)
        {
            Item[i].color = Color.white;
        }

        //if (degrees <= 60)
        //{
        //    Item[0].GetComponent<Image>().color = Color.blue;
        //    Item_num = 0;
        //}

        if (degrees <= 120)
        {
            Item[1].color = Color.blue;
            Item_num = 1;
        }

        else if (degrees <= 180)
        {
            Item[2].color = Color.blue;
            Item_num = 2;
        }

        else if (degrees <= 240)
        {
            Item[3].color = Color.blue;
            Item_num = 3;
        }

        else if (degrees <= 300)
        {
            Item[4].color = Color.blue;
            Item_num = 4;
        }

        else if (degrees <= 360)
        {
            Item[5].color = Color.blue;
            Item_num = 5;
        }

        else
        {

        }
    }

    /// <summary>
    /// アイテム処理
    /// </summary>
    /// <param name="Item_num">Itam list</param>
    public void Item_use(int Item_num)
    {
        switch (Item_num)
        {
            //case 0:
            //    StartCoroutine(CoolTime(Item_num, cool));
            //    //アイテム処理追加
            //    break;
            case 1:
                I_active.Set_Item(_umbrella, true);
                StartCoroutine(CoolTime(Item_num, cool));
                StartCoroutine(I_active.duration(_umbrella, 5.0f));
                Debug.Log("use =" + Item_num);
                break;
            case 2:
                StartCoroutine(CoolTime(Item_num, cool));
                Debug.Log("use =" + Item_num);
                break;
            case 3:
                StartCoroutine(CoolTime(Item_num, cool));
                Debug.Log("use =" + Item_num);
                break;
            case 4:
                StartCoroutine(CoolTime(Item_num, cool));
                Debug.Log("use =" + Item_num);
                break;
            case 5:
                StartCoroutine(CoolTime(Item_num, cool));
                Debug.Log("use =" + Item_num);
                break;
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
