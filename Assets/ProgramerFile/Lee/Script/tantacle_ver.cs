using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tantacle_ver : MonoBehaviour
{
    Vector3 StartPos;
    Vector3 pos;

    Collider2D col;

    void Start()
    {
        col = GetComponent<Collider2D>();

        StartCoroutine(Moving());
        pos = transform.position;
        StartPos = transform.position;
    }
   
    // Update is called once per frame
 
    private void OnTriggerEnter2D(Collider2D col)
    {
        //Enemy(tentacle)
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    /// <summary>
    /// tantacle_moveing
    /// </summary>
    /// <returns></returns>
    private IEnumerator Moving()
    {
        float temp = 0;
        pos = transform.position;
        yield return new WaitForSeconds(2.0f);
        while (temp < 1)
        {
            pos.y = Mathf.Lerp(StartPos.y, -4.0f, temp);
            temp += Time.deltaTime;
            transform.position = pos;
            yield return new WaitForFixedUpdate();
        }

        col.enabled = false;
        while (temp > 0)
        {
            pos.y = Mathf.Lerp(StartPos.y, -4.0f, temp);
            temp -= Time.deltaTime;
            transform.position = pos;
            yield return new WaitForFixedUpdate();
        }
        Destroy(gameObject, 1.0f);
        tentacle_ver_controll.attackable = true;
    }


}
