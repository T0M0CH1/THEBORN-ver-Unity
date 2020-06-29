﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    [SerializeField]
    private Sprite[] batteryImage;
    [HideInInspector]
    public static int battery;
    [SerializeField]
    private GameObject _battery;
    [HideInInspector]
    public static bool is_charging; //充電する、しない　判定
    [SerializeField]
    public static float decrease_speed = 0.5f; // Battery減らす。speed



    void Start()
    {
        is_charging = false;
        battery = 6;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    battery--;
        //}
        switch (battery)
        {
            case 0:
                _battery.GetComponent<Image>().sprite = batteryImage[0];
                break;
            case 1:
                _battery.GetComponent<Image>().sprite = batteryImage[1];
                break;
            case 2:
                _battery.GetComponent<Image>().sprite = batteryImage[2];
                break;
            case 3:
                _battery.GetComponent<Image>().sprite = batteryImage[3];
                break;
            case 4:
                _battery.GetComponent<Image>().sprite = batteryImage[4];
                break;
            case 5:
                _battery.GetComponent<Image>().sprite = batteryImage[5];
                break;
            case 6:
                _battery.GetComponent<Image>().sprite = batteryImage[6];
                break;
        }
    }

    /// <summary>
    /// バッテリー持続時間
    /// </summary>
    /// <param name="dur">減らす時間</param>
    /// <returns></returns>
    public static IEnumerator decrease(float dur)
    {
        yield return new WaitForSeconds(dur);
        while (true)
        {

            if (Player.SW_Light == false)
            {
                yield break;
            }
            battery--;
            yield return new WaitForSeconds(dur);
            
        }
       
    }


    /// <summary>
    /// Battery回復
    /// </summary>
    /// <param name="dur">回復時間</param>
    /// <returns></returns>
    public static IEnumerator charg(float dur)
    {
        if (is_charging == true)
        {
           yield break;
        }
        is_charging = true;
        Debug.Log("charging");
        while (battery < 6)
        {
            battery++;
            yield return new WaitForSeconds(dur);
        }
        is_charging = false;
        Debug.Log("charging exit");
    }
}
