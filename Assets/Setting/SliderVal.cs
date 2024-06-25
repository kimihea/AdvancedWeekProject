using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderVal : MonoBehaviour
{
    Slider slider;
    public AudioMixerGroup audioMixerGroup;
    public string str;
    void Start()
    {
        float volume;
        slider = GetComponent<Slider>();
        audioMixerGroup.audioMixer.GetFloat(str, out  volume);
        slider.value = Mathf.Pow(10, volume / 20);
    }

    public void OnValueChanged()
    {
        float volume = Mathf.Log10(slider.value) * 20;
        audioMixerGroup.audioMixer.SetFloat(str, volume);
    }

}
