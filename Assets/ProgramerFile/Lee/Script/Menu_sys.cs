using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_sys : MonoBehaviour
{

    [SerializeField]
    GameObject Menu;

    [SerializeField]
    GameObject[] Item;

    int Item_num;

    void Start()
    {
        Menu.SetActive(false);
    }

    void Update()
    {

        float Rsh = Input.GetAxis("R_Stick_H");
        float Rsv = Input.GetAxis("R_Stick_V");

        if (Input.GetKey("joystick button 5")) //Button_R_B
        {
            Menu.SetActive(true);

            if ((Rsh != 0) || (Rsv != 0))
            {
                Item_Select(GetAngle(Rsh, Rsv));
            }

        }

        if (Input.GetKeyUp("joystick button 5")) //Button_R_B
        {
            Item_use(Item_num);
            Menu.SetActive(false);
        }
    }

    //---------------------------------------------------------
    //---------------------------------------------------------
    private float GetAngle(float x, float y)
    {
        float degrees = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        degrees = (degrees + 360) % 360;
        return degrees;
    }

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

    private void Item_use(int Item_num)
    {
        switch (Item_num)
        {
            case 0:
                Debug.Log("use =" + Item_num);
                break;
            case 1:
                Debug.Log("use =" + Item_num);
                break;
            case 2:
                Debug.Log("use =" + Item_num);
                break;
            case 3:
                Debug.Log("use =" + Item_num);
                break;
            case 4:
                Debug.Log("use =" + Item_num);
                break;
            case 5:
                Debug.Log("use =" + Item_num);
                break;
            default:
                break;
        }

    }
}
