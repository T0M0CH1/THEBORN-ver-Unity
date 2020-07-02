using UnityEngine;

public class SettingUI : MonoBehaviour
{
    [SerializeField]
    private GameObject settingUI;
    void Update()
    {
        if (Input.GetKeyDown("joystick button 7") && settingUI.gameObject.activeSelf == false || Input.GetKeyDown(KeyCode.Escape) && settingUI.gameObject.activeSelf == false)
        {
            Time.timeScale = 0;
            settingUI.SetActive(true);
        }
        else if (Input.GetKeyDown("joystick button 7") && settingUI.gameObject.activeSelf == true || Input.GetKeyDown(KeyCode.Escape) && settingUI.gameObject.activeSelf == true)
        {
            Time.timeScale = 1;
            settingUI.SetActive(false);
        }
    }
}
