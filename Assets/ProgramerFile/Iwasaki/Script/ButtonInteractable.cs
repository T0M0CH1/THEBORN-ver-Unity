using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractable : MonoBehaviour
{
    [SerializeField]
    private Button button;

    // Update is called once per frame
    void Update()
    {
        if (SaveData.halfwayBool == false)
        {
            button.interactable = false;
        }
    }
}
