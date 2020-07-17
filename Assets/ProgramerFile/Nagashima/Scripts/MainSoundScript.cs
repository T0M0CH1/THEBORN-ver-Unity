using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSoundScript : MonoBehaviour
{

    GameObject MainSoundObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

        // Update is called once per frame
        void Update()
        {

        }

    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MainSoundScript>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(MainSoundObject);
        }
        else
        {
            DontDestroyOnLoad(MainSoundObject); // シーンを切り替えたときにオブジェクトが破棄されなくなる
        }
    }

}
