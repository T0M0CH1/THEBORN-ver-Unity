using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEkari : MonoBehaviour
{
    [SerializeField]
    private AudioClip onButtonSE;
    [SerializeField]
    private AudioClip selectSE;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayingSEonButton()
    {
        audio.PlayOneShot(onButtonSE, 0.7F);
    }
    public void PlayingSESelect()
    {
        audio.PlayOneShot(selectSE, 0.7F);
    }
}
