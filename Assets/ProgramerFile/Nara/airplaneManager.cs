using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airplaneManager : MonoBehaviour
{

    int positionX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        positionX++;

        //プレイヤーを移動
        transform.position = new Vector3(positionX, -4, -1);



    }
}
