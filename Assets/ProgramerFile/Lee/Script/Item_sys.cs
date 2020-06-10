using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_sys : MonoBehaviour
{
    [SerializeField]
    GameObject Item_controller;

    [SerializeField]
    GameObject[] Item;

    [SerializeField]
    Image[] img_Skill;


    [SerializeField, Range(0.0f, 5.0f)]
    float cool = 5.0f; // Cool Down

    int Item_num; //Item 選択判定
    bool[] Item_flag = new bool[6]; //Item Cool Down 判定する変数

    void Start()
    {
        Item_flag_init();
        Item_controller.SetActive(false);
    }

    void Update()
    {

        float Rsh = Input.GetAxis("R_Stick_H"); // Game_Pad 右スティックの右左を取得
        float Rsv = Input.GetAxis("R_Stick_V"); // Game_Pad 右スティックの上下を取得

        if (Input.GetKey("joystick button 5")) //Button_R_B
        {
            Item_controller.SetActive(true);

            if ((Rsh != 0) || (Rsv != 0))
            {
                Item_Select(GetAngle(Rsh, Rsv));
            }

        }

        if (Input.GetKeyUp("joystick button 5")) //Button_R_B
        {
            Item_use(Item_num);
            Item_controller.SetActive(false);
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
            Item[i].GetComponent<Image>().color = Color.white;
        }

        if (degrees <= 60)
        {
            Item[0].GetComponent<Image>().color = Color.blue;
            Item_num = 0;
        }

        else if (degrees <= 120)
        {
            Item[1].GetComponent<Image>().color = Color.blue;
            Item_num = 1;
        }

        else if (degrees <= 180)
        {
            Item[2].GetComponent<Image>().color = Color.blue;
            Item_num = 2;
        }

        else if (degrees <= 240)
        {
            Item[3].GetComponent<Image>().color = Color.blue;
            Item_num = 3;
        }

        else if (degrees <= 300)
        {
            Item[4].GetComponent<Image>().color = Color.blue;
            Item_num = 4;
        }

        else if (degrees <= 360)
        {
            Item[5].GetComponent<Image>().color = Color.blue;
            Item_num = 5;
        }
    }

    /// <summary>
    /// アイテム使用
    /// </summary>
    /// <param name="Item_num">Itam list</param>
    private void Item_use(int Item_num)
    {
        switch (Item_num)
        {
            case 0:
                StartCoroutine(CoolTime(Item_num, cool));
                Debug.Log("use =" + Item_num);
                break;
            case 1:
                StartCoroutine(CoolTime(Item_num, cool));
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
        for (int i = 0; i < 6; i++)
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
