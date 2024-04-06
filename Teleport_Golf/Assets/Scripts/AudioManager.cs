using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundMusicPref = "BackgroundMusicPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";

    private int firstPlayInt;
    public Slider BackgroundMusicSlider, SoundEffectsSlider;
    private float BackgroundMusicFloat, SoundEffectsFloat;

    public AudioSource BackgroundMusicAudio;
    public AudioSource[] SoundEffectsAudio;

    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if (firstPlayInt == 0)
        {
            BackgroundMusicFloat = .25f;
            SoundEffectsFloat = .75f;
            BackgroundMusicSlider.value = BackgroundMusicFloat;
            SoundEffectsSlider.value = SoundEffectsFloat;
            PlayerPrefs.SetFloat(BackgroundMusicPref, BackgroundMusicFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, SoundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            BackgroundMusicFloat = PlayerPrefs.GetFloat(BackgroundMusicPref);
            BackgroundMusicSlider.value = BackgroundMusicFloat;

            SoundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            SoundEffectsSlider.value = SoundEffectsFloat;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveAudioSettings()
    {
        PlayerPrefs.SetFloat(BackgroundMusicPref, BackgroundMusicSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, SoundEffectsSlider.value);
    }

    public void UpdateSound()
    {
        BackgroundMusicAudio.volume = BackgroundMusicSlider.value;
        for (int i = 0; i < SoundEffectsAudio.Length; i++)
        {
            SoundEffectsAudio[i].volume = SoundEffectsSlider.value;
        }
    }
}
