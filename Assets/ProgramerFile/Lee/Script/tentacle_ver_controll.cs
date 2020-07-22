using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacle_ver_controll : MonoBehaviour
{
    [SerializeField]
    GameObject tentacl_vet_controll;

    [SerializeField]
    GameObject[] Respawn_ver;

    [SerializeField]
    GameObject Respawn_hori;

    [SerializeField]
    GameObject prefab_ver;

    [SerializeField]
    GameObject prefab_hori;

    GameObject[] obj = new GameObject[10];

    public static bool attackable = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(hori_ver_tentacle_init());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = cam.transform.position;

    }

    void tentacle_ver_init()
    {
        int rnd = Random.Range(3, Respawn_ver.Length);
        for (int i = 0; i < rnd; i++)
        {
            int rnd_pos = Random.Range(0, Respawn_ver.Length);
            //obj[i] = Instantiate(prefab, Respawn[i].transform.position, Quaternion.identity);
            obj[i] = Instantiate(prefab_ver, Respawn_ver[rnd_pos].transform.position, Quaternion.identity);
            //obj[i].transform.parent = tentacl_vet_controll.transform;
        }
    }
    

    void tentacle_hori_init()
    {
        Instantiate(prefab_hori, Respawn_hori.transform.position , Quaternion.identity);
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
}
