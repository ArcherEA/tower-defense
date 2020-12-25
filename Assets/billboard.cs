using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboard : MonoBehaviour
{
    private Transform cam;
   
    void Awake()
    {
        cam=Camera.main.transform;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (cam!=null)
        {
            transform.LookAt(transform.position+cam.forward);
        }
    }
}
