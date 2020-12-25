using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class speed_up_control : MonoBehaviour
{
    public GameObject pausemenu;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pausemenu.activeSelf)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
