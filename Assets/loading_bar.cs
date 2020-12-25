using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loading_bar : MonoBehaviour
{
    public Slider slider;

    //public Gradient gradient;
    public Image fill;
    public void SetMaxNum(float Num)
    {
        slider.maxValue = Num;
        slider.value = 0;

       // fill.color=gradient.Evaluate(1f);
    }
    public void SetNum(float Num)
    {
        slider.value=Num;
        //fill.color=gradient.Evaluate(slider.normalizedValue);

    }
}
