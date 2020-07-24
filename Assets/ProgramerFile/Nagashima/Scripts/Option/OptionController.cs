using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

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