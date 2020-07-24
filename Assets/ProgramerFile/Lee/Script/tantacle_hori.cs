using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tantacle_hori : MonoBehaviour
{
    Vector3 pos;
    Vector3 temp_pos;

    Collider2D col;

    void Start()
    {
        col=GetComponent<Collider2D>();
        StartCoroutine(Moving());
        pos = transform.position;
        temp_pos = tentacle_hori_pos.Global_pos;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        //if (temp < 1)
        //{
        //    pos.x = Mathf.Lerp(-10.0f, 10.0f, temp);
        //    temp += Time.deltaTime * 2;
        //    transform.position = pos;
        //}

        //else
        //{
        //    pos.x = Mathf.Lerp(-10.0f, 10.0f, temp);
        //    temp -= Time.deltaTime * 2;
        //    transform.position = pos;
        //}

    }

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
        yield return new WaitForSeconds(2.0f);
        while (temp < 1)
        {
            pos.x = Mathf.Lerp(temp_pos.x , temp_pos.x + 20.0f, temp);
            temp += Time.deltaTime;
            transform.position = pos;
            yield return new WaitForFixedUpdate();
        }

        col.enabled = false;
        while (temp > 0)
        {
            pos.x = Mathf.Lerp(temp_pos.x , temp_pos.x + 20.0f , temp);
            temp -= Time.deltaTime;
            transform.position = pos;
            yield return new WaitForFixedUpdate();
        }
        tentacle_ver_controll.attackable = true;
        Destroy(gameObject, 1.0f);
    }

 
}
