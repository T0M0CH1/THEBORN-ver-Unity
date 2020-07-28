using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEndMovie : MonoBehaviour
{
    float StepTime;

    void Start()
    {
        StepTime = 0.0f;
    }

    void Update()
    {
        StepTime += Time.deltaTime;

        if (StepTime >= 5.0f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
