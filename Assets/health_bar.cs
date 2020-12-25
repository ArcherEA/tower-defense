using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class health_bar : MonoBehaviour
{
  
    public Slider slider;

    //public Gradient gradient;
    public Image fill;
    public void SetMaxHealth(float Health)
    {
        slider.maxValue = Health;
        slider.value = Health;

       // fill.color=gradient.Evaluate(1f);
    }
    public void SetHealth(float Health)
    {
        slider.value=Health;
        //fill.color=gradient.Evaluate(slider.normalizedValue);

    }

}
