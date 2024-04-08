using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMultipleScenes : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundMusicPref = "BackgroundMusicPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";

    private float BackgroundMusicFloat, SoundEffectsFloat;
    private int firstPlayInt;

    public AudioSource BackgroundMusicAudio;
    public AudioSource[] SoundEffectsAudio;

    private void Awake()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if (firstPlayInt == 0)
        {
            BackgroundMusicFloat = .25f;
            SoundEffectsFloat = .75f;
            PlayerPrefs.SetFloat(BackgroundMusicPref, BackgroundMusicFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, SoundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            BackgroundMusicFloat = PlayerPrefs.GetFloat(BackgroundMusicPref);

            SoundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
        }

        ContinueSettings();
    }

    private void ContinueSettings()
    {
        BackgroundMusicFloat = PlayerPrefs.GetFloat(BackgroundMusicPref);

        SoundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);

        BackgroundMusicAudio.volume = BackgroundMusicFloat;

        for (int i = 0; i < SoundEffectsAudio.Length; i++)
        {
            SoundEffectsAudio[i].volume = SoundEffectsFloat;
        }
    }
}
