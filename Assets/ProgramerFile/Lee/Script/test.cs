using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{


    //struct Button
    //{
    //    bool A = Input.GetKeyDown("joystick button 0"); //Button_A
    //    bool B = Input.GetKeyDown("joystick button 1"); //Button_B
    //    bool X = Input.GetKeyDown("joystick button 2"); //Button_X
    //    bool Y = Input.GetKeyDown("joystick button 3"); //Button_Y
    //    bool LB = Input.GetKeyDown("joystick button 4"); //Button_L_B
    //    bool RB = Input.GetKeyDown("joystick button 5"); //Button_R_B
    //    bool S = Input.GetKeyDown("joystick button 6"); //Button_S
    //    bool Menu = Input.GetKeyDown("joystick button 7"); //Button_Menu
    //}

    [SerializeField]
    GameObject Menu;

    [SerializeField]
    GameObject[] Item;

    int Item_num;



    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("joystick button 0")) //Button_A
        //{
        //    Debug.Log("button0");
        //}
        //if (Input.GetKeyDown("joystick button 1")) //Button_B
        //{
        //    Debug.Log("button1");
        //}
        //if (Input.GetKeyDown("joystick button 2")) //Button_X
        //{
        //    Debug.Log("button2");
        //}
        //if (Input.GetKeyDown("joystick button 3")) //Button_Y
        //{
        //    Debug.Log("button3");
        //}

        float Rsh = Input.GetAxis("R_Stick_H");
        float Rsv = Input.GetAxis("R_Stick_V");

        if (Input.GetKeyDown("joystick button 4")) //Button_L_B
        {
            //Debug.Log("button4");
        }

        if (Input.GetKey("joystick button 5")) //Button_R_B
        {
            Menu.SetActive(true);

            if ((Rsh != 0) || (Rsv != 0))
            {
                //Debug.Log(GetAngle(Rsh, Rsv));
                Item_Select(GetAngle(Rsh, Rsv));

            }

        }
        if(Input.GetKeyUp("joystick button 5"))
        {
            Item_use(Item_num);
            Menu.SetActive(false);
        }

        //if (Input.GetKeyDown("joystick button 6")) //Button_Sarring
        //{
        //    Debug.Log("button6");
        //}
        //if (Input.GetKeyDown("joystick button 7")) ////Button_Menu
        //{
        //    Debug.Log("button7");
        //}
        //if (Input.GetKeyDown("joystick button 8"))
        //{
        //    Debug.Log("button8");
        //}
        //if (Input.GetKeyDown("joystick button 9"))
        //{
        //    Debug.Log("button9");
        //}


        //float hori = Input.GetAxis("Horizontal");
        //float vert = Input.GetAxis("Vertical");
        //if ((hori != 0) || (vert != 0))
        //{
        //    Debug.Log("stick:" + hori + "," + vert);
        //}

        

      
        //float tri = Input.GetAxis("L_R_Trigger");

        //if (tri > 0)
        //{
        //    Debug.Log("L stick:" + Rsh + "," + Rsv);
        //}

        //else if (tri < 0)
        //{
        //    Debug.Log("R trigger:" + tri);
        //}


    }

    private float GetAngle (float x, float y)
    {
        float degrees = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        degrees = (degrees + 360) % 360;
        return degrees;
    }

    private void Item_Select(float degrees)
    {
        for(int i = 0; i < 6; i++)
        {
            Item[i].GetComponent<Image>().color = Color.white;
        }

        if (degrees <= 60)
        {
            Item[0].GetComponent<Image>().color = Color.blue;
            Item_num = 0;
        }

        else if(degrees <= 120)
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

        //switch (degrees)
        //{
        //    case 0:
        //        Item[0].GetComponent<Image>().color = Color.blue;
        //        break;
        //    case 1:
        //        Item[0].GetComponent<Image>().color = Color.blue;
        //        break;
        //    case 2:
        //        Item[0].GetComponent<Image>().color = Color.blue;
        //        break;
        //    case 3:
        //        Item[0].GetComponent<Image>().color = Color.blue;
        //        break;
        //    case 4:
        //        Item[0].GetComponent<Image>().color = Color.blue;
        //        break;
        //    default:
        //        break;
        //}

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
