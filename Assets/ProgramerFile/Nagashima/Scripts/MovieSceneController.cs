﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovieSceneController : MonoBehaviour
{
    private float step_time;  // 経過時間カウント

    // Start is called before the first frame update
    void Start()
    {
        step_time = 0.0f; // 経過時間初期化
    }

    // Update is called once per frame
    void Update()
    {
        // 経過時間をカウント
        step_time += Time.deltaTime;

        // 5秒後に画面遷移
        if(step_time>=5.0f)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
