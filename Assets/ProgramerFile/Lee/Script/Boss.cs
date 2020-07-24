using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private float wait_time = 2.0f;

    [SerializeField]
    public static int Life = 3;

    private Vector3 Cloaking = new Vector3 (20.0f,20.0f,20.0f);

    //[SerializeField]
    //private GameObject[] _mirror;

    //[SerializeField]
    //private GameObject mirror_prefab;

    //private GameObject[] obj = new GameObject[5];

    private int rnd = 0;
    private int temp = 0;

    public static bool call;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Moving(wait_time));
    }

    // Update is called once per frame
    void Update()
    {
        if(call == true)
        {
            transform.position = Player.mirror_obj.transform.position;
            Destroy(Player.mirror_obj);
            call = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Light")
        {
            transform.position = Cloaking;
            Life--;
        }
    }

    /// <summary>
    /// Boss 移動
    /// </summary>
    /// <param name="dur">wait Moving</param>
    /// <returns></returns>
    //private IEnumerator Moving(float dur)
    //{
    //    yield return new WaitForSeconds(dur);

    //    while (temp == rnd)
    //    {
    //        rnd = Random.Range(0, 3);
    //    }
    //    transform.position = _mirror[rnd].transform.position;
    //    temp = rnd;
    //    StartCoroutine(Moving(dur));
    //}

    //void obj_Init()
    //{
    //    int count = 0;
    //    for(int i = 0; i < obj.Length; i++)
    //    {
    //        obj[i] = Instantiate(mirror_prefab, new Vector3(0,0,0) , Quaternion.identity);
    //    }
    //}
}
