using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterVolume : MonoBehaviour
{

    [SerializeField] // Unity側で値をいじれるようにする
    private AudioMixer mixer;　// オーディオミキサーを

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMaster(float volume)
    {
        mixer.SetFloat("MasterVol", volume);
    }

    public void SetBGM(float volume)
    {
        mixer.SetFloat("BGMVol", volume);
    }

    public void SetSE(float volume)
    {
        mixer.SetFloat("SEVol", volume);
    }
}
