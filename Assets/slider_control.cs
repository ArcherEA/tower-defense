using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class slider_control : MonoBehaviour
{
    public Slider slider;
    public GameObject camera;
    public void change_value()
    {
        camera.GetComponent<camera_controller>().cameraheightcontrol(slider.value*10);
    }
}
