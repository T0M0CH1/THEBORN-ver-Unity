using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void toSTART()
    {
        Player.halfwayBool = false;
        SceneManager.LoadScene("Iwasaki");
    }
    public void toCONTINUE()
    {
        SceneManager.LoadScene("Iwasaki");
    }
}
