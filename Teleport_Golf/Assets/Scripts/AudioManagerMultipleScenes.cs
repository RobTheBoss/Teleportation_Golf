using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMultipleScenes : MonoBehaviour
{
    private static readonly string BackgroundMusicPref = "BackgroundMusicPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";

    private float BackgroundMusicFloat, SoundEffectsFloat;

    public AudioSource BackgroundMusicAudio;
    public AudioSource[] SoundEffectsAudio;

    private void Awake()
    {
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
