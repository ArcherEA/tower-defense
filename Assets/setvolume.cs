using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class setvolume : MonoBehaviour
{
    public AudioMixer mixer;
    public string PARAMETER;
    public void Setlevel(float sliderVaule)
    {
        Debug.Log("change");
        mixer.SetFloat(PARAMETER,Mathf.Log10(sliderVaule)*20f);

    }
}
