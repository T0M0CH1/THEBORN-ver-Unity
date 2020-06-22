using System.Collections;
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
    void Start()
    {
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
    public static IEnumerator duration(float dur)
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
}
