using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrueEndTrans : MonoBehaviour
{
    private void Update()
    {
        if(Boss.Life<=0)
        {
            SceneManager.LoadScene("TrueEnd");
        }
    }
}
