using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour
{
    string _sceneName;

    // Start is called before the first frame update
    void Start()
    {
        _sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (_sceneName)
            {
                case "MainScene(alpha)":
                    SceneManager.LoadScene("MainScene(alpha)_stage2");
                    break;

                case "MainScene(alpha)_stage2":
                    SceneManager.LoadScene("MainScene(alpha)_stage3");
                    break;

                case "MainScene(alpha)_stage3":
                    SceneManager.LoadScene("Boss");
                    break;

            }


        }
    }
}
