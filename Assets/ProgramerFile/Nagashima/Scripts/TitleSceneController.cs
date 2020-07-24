using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buttonclicked()
    {
        SaveData.halfwayBool = false;
        SceneManager.LoadScene("Movie");
    }
    //iwasaki追加

    public void Continue()
    {
        SceneManager.LoadScene("MainScene");
    }
}