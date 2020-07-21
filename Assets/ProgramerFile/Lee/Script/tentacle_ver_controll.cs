using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacle_ver_controll : MonoBehaviour
{
    [SerializeField]
    GameObject cam;

    [SerializeField]
    GameObject tentacl_vet_controll;

    [SerializeField]
    GameObject[] Respawn;

    [SerializeField]
    GameObject prefab;

    GameObject[] obj = new GameObject[10]; 

    // Start is called before the first frame update
    void Start()
    {
        int rnd = Random.Range(3, Respawn.Length);
        for (int i = 0; i < rnd; i++)
        {
            int rnd_pos = Random.Range(0, Respawn.Length);
            //obj[i] = Instantiate(prefab, Respawn[i].transform.position, Quaternion.identity);
            obj[i] = Instantiate(prefab, Respawn[rnd_pos].transform.position, Quaternion.identity);
           //obj[i].transform.parent = tentacl_vet_controll.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = cam.transform.position;
    }

  
}
