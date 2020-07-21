using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tantacle_ver : MonoBehaviour
{
    Vector3 StartPos;
    Vector3 pos;
    float temp = 0;

    void Start()
    {
        StartCoroutine(Moving());
        pos = transform.position;
        StartPos = transform.position;
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Enemy(tentacle)
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private IEnumerator Moving()
    {
        float temp = 0;
        pos = transform.position;
        yield return new WaitForSeconds(1.0f);
        while (temp < 1)
        {
            pos.y = Mathf.Lerp(StartPos.y, 5.0f, temp);
            temp += Time.deltaTime;
            transform.position = pos;
            yield return new WaitForFixedUpdate();
        }

        while (temp > 0)
        {
            pos.y = Mathf.Lerp(StartPos.y, 5.0f, temp);
            temp -= Time.deltaTime;
            transform.position = pos;
            yield return new WaitForFixedUpdate();
        }
        Destroy(gameObject, 1.0f);
    }


}
