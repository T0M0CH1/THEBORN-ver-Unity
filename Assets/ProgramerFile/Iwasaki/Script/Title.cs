using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void toSTART()
    {
        SaveData.halfwayBool = false;
        SceneManager.LoadScene("MainScene");
    }
    public void toCONTINUE()
    {
        if (SaveData.is_saved)
        {
            SceneManager.LoadScene(SaveData.sceneName);
        }
        else
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
