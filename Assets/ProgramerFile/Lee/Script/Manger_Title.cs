using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Manger_Title : MonoBehaviour
{

    [SerializeField]
    private Image[] Menu_Bar;

    private int Menu_Num;
    private int Menu_Size;

    private float Menu_Move_X;
    private float Menu_Move_Y;
    // Start is called before the first frame update
    void Start()
    {
        Menu_Num = 0;
        Menu_Size = Menu_Bar.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Menu_Bar[Menu_Num].color = Color.red;


        if (Input.GetKeyDown("joystick button 1"))
        {
            Move_Scens();
        }



    }

    private void FixedUpdate()
    {
        Menu_Move_X = Input.GetAxis("D_Pad_H");
        Menu_Move_Y = Input.GetAxis("D_Pad_V"); ;

        if (Menu_Move_Y == 1 && Menu_Num > 0)
        {
            Rest_Color();
            Menu_Num--;
        }

        else if (Menu_Move_Y == -1 && Menu_Num < Menu_Size - 1)
        {
            Rest_Color();
            Menu_Num++;
        }
        Debug.Log(Menu_Num);
    }
    //================================================

    private void Rest_Color()
    {
        for (int i = 0; i < Menu_Size; i++)
        {
            Menu_Bar[Menu_Num].color = Color.white;
        }
    }

    private void Move_Scens()
    {
        switch (Menu_Num)
        {
            case 0:
                SceneManager.LoadScene("MainScene");
                break;

            case 1:
                SceneManager.LoadScene("MainScene");
                break;

            case 2:
                SceneManager.LoadScene("Option");
                break;
        }
    }

}
