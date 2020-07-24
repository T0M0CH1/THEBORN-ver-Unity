using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WachingBar : MonoBehaviour
{

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Slider slider;
    private Vector3 offset = new Vector3(0, -1.0f, 0);
    //===========================================

    public static float Gauge = 0;
    public static bool is_Washing = false;

    //===========================================
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //UIがキャラを追跡
        transform.position
            = RectTransformUtility.WorldToScreenPoint(Camera.main, target.position + offset);

        if(is_Washing)　//鏡を洗い開始
        {
            Gauge = 0;
            StartCoroutine(End_Waching());
        }

    }


    //=======================================================
    //=======================================================

    /// <summary>
    /// Gaugeが全部満たす（洗いが終わる）とbossを呼び出す
    /// </summary>
    /// <returns></returns>
    private IEnumerator End_Waching()
    {
        yield return new WaitUntil(() => is_Washing); // if is_Washing is true, next process
        Player.Jumpable = false;
        Player.moveable = false;
        while (Gauge < 1.0f)
        {
            slider.value = Gauge;
            yield return new WaitForSeconds(0.01f);
            Gauge += Time.deltaTime;
        }

        yield return new WaitUntil(() => Gauge >= 1.0f); // if Gauge is Greater than 1.0f, next process

        is_Washing = false;
        Player.Jumpable = true;
        Player.moveable = true;

        Boss.call = true; //bossを呼び出す

        gameObject.SetActive(false);
    }
}
