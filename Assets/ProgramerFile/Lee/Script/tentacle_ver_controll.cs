using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacle_ver_controll : MonoBehaviour
{
    [SerializeField]
    GameObject tentacl_vet_controll;

    [SerializeField]
    GameObject[] Respawn_ver;//縦向き攻撃生成位置

    [SerializeField]
    GameObject Respawn_hori; //横向き攻撃生成位置

    [SerializeField]
    GameObject prefab_ver; //縦向き攻撃オブジェクト

    [SerializeField]
    GameObject prefab_hori; //横向き攻撃オブジェクト

    [SerializeField]
    GameObject prefab_tantacle_effect_ver; //横向き攻撃オブジェクト    
    [SerializeField]
    GameObject prefab_tantacle_effect_hori;　//横向き攻撃オブジェクト

    GameObject[] obj = new GameObject[50];

    public static bool attackable;

    int rnd_pos_temp = 0;
    int rnd_pos;


    private void Awake()
    {
        //StartCoroutine(hori_ver_tentacle_init());
    }

    void Start()
    {
        attackable = true;
        StartCoroutine(hori_ver_tentacle_init());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator hori_ver_tentacle_init()
    {
        yield return new WaitUntil(() => attackable);

        int rnd;

        rnd = Random.Range(0, 2);
        switch (rnd)
        {
            case 0:
                tentacle_ver_init();
                break;
            case 1:
                tentacle_hori_init();
                break;
        }
        attackable = false;
        StartCoroutine(hori_ver_tentacle_init());
    }

    void tentacle_ver_init()
    {
        int rnd = Random.Range(2, Respawn_ver.Length);
        for (int i = 0; i < rnd; i++)
        {
            rnd_pos = Random.Range(0, Respawn_ver.Length);
            if(rnd_pos == rnd_pos_temp - 1 || rnd_pos == rnd_pos_temp + 1 || rnd_pos == rnd_pos_temp)
            {
                i--;
                continue;
            }
            //obj[i] = Instantiate(prefab, Respawn[i].transform.position, Quaternion.identity);
            obj[i] = Instantiate(prefab_ver, Respawn_ver[rnd_pos].transform.position, Quaternion.identity);
            Instantiate(prefab_tantacle_effect_ver, Respawn_ver[rnd_pos].transform.position, Quaternion.identity);

            //obj[i].transform.parent = tentacl_vet_controll.transform;
            rnd_pos_temp = rnd_pos;
        }
    }
    

    void tentacle_hori_init()
    {
        Instantiate(prefab_hori, Respawn_hori.transform.position , Quaternion.identity);
        Instantiate(prefab_tantacle_effect_hori, Respawn_hori.transform.position , Quaternion.identity);
    }

    void tentacle_ver_effect_init()
    {
    }

    /// <summary>
    /// 横、縦の攻撃をランダムして攻撃
    /// </summary>
    void hori_ver_tentacle_init01()
    {
        int rnd;

        rnd = Random.Range(0, 2);
        switch (rnd)
        {
            case 0:
                tentacle_ver_init();
                break;
            case 1:
                tentacle_hori_init();
                break;
        }
    }
}
