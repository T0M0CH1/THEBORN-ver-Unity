using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OptionController : MonoBehaviour
{
    public AudioMixer Mixer;


    // インスペクター上からスライダーオブジェクトを登録
    public Slider MasterSlider;
    public Slider BGMSlider;
    public Slider SeSlider;

    private void Start()
    {
        float Volume;

        // Mixer.GetFloat()の値は、volumeに代入される
        // 返り値は、パラメーターが存在しない場合にfalseになる
        if (Mixer.GetFloat("MasterVol", out Volume))
        {
            MasterSlider.value = Volume;
        }

        if (Mixer.GetFloat("BGMVol", out Volume))
        {
            BGMSlider.value = Volume;
        }

        if (Mixer.GetFloat("SEVol", out Volume))
        {
            SeSlider.value = Volume;
        }
    }

    private void Update()
    {
        MasterSlider.value += Input.GetAxis("Horizontal");
        BGMSlider.value += Input.GetAxis("Horizontal");
        SeSlider.value += Input.GetAxis("Horizontal");
    }

    public void MasterVol(Slider slider)
    {
        Mixer.SetFloat("MasterVol", slider.value);
    }

    public void BGMVol(Slider slider)
    {
        Mixer.SetFloat("BGMVol", slider.value);
    }

    public void SEVol(Slider slider)
    {
        Mixer.SetFloat("SEVol", slider.value);
    }

    // ミキサー操作
    [SerializeField]
    private AudioMixer mixer;

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