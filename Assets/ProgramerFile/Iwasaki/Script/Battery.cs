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
    public static int battery = 7;
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
    private bool doOnce = true;
    [SerializeField]
    private GameObject chargeImage;




    void Start()
    {
        is_charging = false;
    }

    // Update is called once per frame
    void Update()
    {
        //充電中はバッテリーが充電中の画像に挿し変わる
        if (Player.catchForm && doOnce)
        {
            doOnce = false;
            chargeImage.SetActive(true);
        }
        else if(Player.catchForm == false && doOnce == false)
        {
            doOnce = true;
            chargeImage.SetActive(false);
        }

        //点滅パターンの作成
        alpha_Sin = Mathf.Sin(Time.time * flashSpeed) / 2 + 0.5f;

        //ライトを消しているときバッテリーが灰色になる
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

        //バッテリー残量に応じての処理
        switch (battery)
        {
            case 0:
                SceneManager.LoadScene("GameOver");
                battery = 7;
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
        Player.Jumpable = false;
        Player.moveable = false;

        Debug.Log("charging");
        while (battery < 7)
        {            
            battery++;
            yield return new WaitForSeconds(dur);
        }
        is_charging = false;
        Player.Jumpable = true;
        Player.moveable = true;

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
