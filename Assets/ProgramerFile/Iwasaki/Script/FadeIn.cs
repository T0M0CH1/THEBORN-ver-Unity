using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    private GameObject fadeCanvas;
    [SerializeField]
    private GameObject player;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = player.GetComponent<Rigidbody2D>();
        rb2d.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        //フェード用のキャンバス作成
        fadeCanvas = new GameObject("FadeCanvas");
        fadeCanvas.transform.SetParent(transform);

        Canvas canvas = fadeCanvas.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 999;
        fadeCanvas.AddComponent<CanvasGroup>();
        fadeCanvas.GetComponent<CanvasGroup>().alpha = 1;

        //フェード用の画像作成
        GameObject imageObject = new GameObject("Image");
        imageObject.transform.SetParent(fadeCanvas.transform, false);
        imageObject.AddComponent<Image>().color = Color.black;
        imageObject.GetComponent<RectTransform>().sizeDelta = new Vector2(2000, 1200);
        StartCoroutine(inFade(3.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator inFade(float fadeTime)
    {
        float time = 0f;
        while (fadeCanvas.GetComponent<CanvasGroup>().alpha > 0)
        {
            fadeCanvas.GetComponent<CanvasGroup>().alpha = 1 - (time / fadeTime);
            time += Time.deltaTime;
            yield return null;
        }
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        yield break;
    }
}
