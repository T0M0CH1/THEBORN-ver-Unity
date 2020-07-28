using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private GameObject fadeCanvas;
    void Start()
    {
        //フェード用のキャンバス作成
        fadeCanvas = new GameObject("FadeCanvas");
        fadeCanvas.transform.SetParent(transform);

        Canvas canvas = fadeCanvas.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 999;
        fadeCanvas.AddComponent<CanvasGroup>();
        fadeCanvas.GetComponent<CanvasGroup>().alpha = 0;

        //フェード用の画像作成
        GameObject imageObject = new GameObject("Image");
        imageObject.transform.SetParent(fadeCanvas.transform, false);
        imageObject.AddComponent<Image>().color = Color.black;
        imageObject.GetComponent<RectTransform>().sizeDelta = new Vector2(2000, 2000);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Result" && Input.GetKeyDown("joystick button 7") || 
            SceneManager.GetActiveScene().name == "Result" && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FadeOut(2.0f));
        }
    }

    IEnumerator FadeOut(float fadeTime)
    {
        float time = 0f;
        while (fadeCanvas.GetComponent<CanvasGroup>().alpha < 1)
        {
            fadeCanvas.GetComponent<CanvasGroup>().alpha = 1f * (time / fadeTime);
            time += Time.deltaTime;
            yield return null;
        }
        SaveData.halfwayBool = false;
        SceneManager.LoadScene("Boss");
        yield break;
    }
}
