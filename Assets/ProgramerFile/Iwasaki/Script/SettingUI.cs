using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour
{
    [SerializeField]
    private GameObject settingUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 7") || Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            settingUI.SetActive(true);
        }
    }

    public void BackMain()
    {
        Time.timeScale = 1;
        settingUI.SetActive(false);
    }
}
