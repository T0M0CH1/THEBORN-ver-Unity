using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Manger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Boss_replica.HP <= 0)
        {
            //Game_Clear_move
            SceneManager.LoadScene("Game_Clear_move");
            Debug.Log("clear");
            //move Scene clear
        }
    }
}
