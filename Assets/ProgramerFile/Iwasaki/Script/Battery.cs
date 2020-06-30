using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private Material grayScale;
    private float alpha_Sin;
    private bool flashBool;
    [SerializeField]
    private float flashSpeed;




    void Start()
    {
        is_charging = false;
        battery = 7;
    }

    // Update is called once per frame
    void Update()
    {
        alpha_Sin = Mathf.Sin(Time.time * flashSpeed) / 2 + 0.5f;
        if (Player.SW_Light == false)
        {
            flashBool = false;
            _battery.GetComponent<Image>().material = grayScale;
            _battery.GetComponent<Image>().color = new Color(1,1,1,1);
        }
        else
        {
            flashBool = true;
            _battery.GetComponent<Image>().material = null;
        }

        switch (battery)
        {
            case 0:
                SceneManager.LoadScene("GameOver");
                break;
            case 1:                
                if (Player.SW_Light)
                {
                    StartCoroutine(Flashing());
                }
                _battery.GetComponent<Image>().sprite = batteryImage[0];
                break;
            case 2:
                if (Player.SW_Light)
                {
                    StartCoroutine(Flashing());
                }
                _battery.GetComponent<Image>().sprite = batteryImage[1];                
                break;
            case 3:
                if (Player.SW_Light)
                {
                    StartCoroutine(Flashing());
                }
                _battery.GetComponent<Image>().sprite = batteryImage[2];
                break;
            case 4:
                _battery.GetComponent<Image>().sprite = batteryImage[3];
                break;
            case 5:
                _battery.GetComponent<Image>().sprite = batteryImage[4];
                break;
            case 6:
                _battery.GetComponent<Image>().sprite = batteryImage[5];
                break;
            case 7:
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
        while (battery < 7)
        {
            battery++;
            yield return new WaitForSeconds(dur);
        }
        is_charging = false;
        Player.catchForm = false;
        Debug.Log("charging exit");
    }

    private IEnumerator Flashing()
    {
        while (flashBool)
        {
            yield return new WaitForEndOfFrame();

            Color _color = this.gameObject.GetComponent<Image>().color;

            _color.a = alpha_Sin;

            this.gameObject.GetComponent<Image>().color = _color;
        }
    }
}
