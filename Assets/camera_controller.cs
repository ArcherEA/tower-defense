using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class camera_controller : MonoBehaviour
{
    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;
    public float horizonal_min;
    public float vertical_min;
    public float horizonal_max;
    public float vertical_max;
    public float default_y;
    // Start is called before the first frame update
    void Start()
    {
        Input.simulateMouseWithTouches=true;
        default_y=transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButton(0)&&EventSystem.current.IsPointerOverGameObject()==false)
        {
            float h=new float();
            float v=new float();
            if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                Debug.Log("WindowsPlayer");
                h = horizontalSpeed * Input.GetAxis("Mouse X");
                v = verticalSpeed * Input.GetAxis("Mouse Y");
            }
            else if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                Debug.Log("WindowsEditor");
                h = horizontalSpeed * Input.GetAxis("Mouse X");
                v = verticalSpeed * Input.GetAxis("Mouse Y");
            }
            else if(Application.platform == RuntimePlatform.IPhonePlayer)
            {
                Debug.Log("IPhonePlayer");
                v = 0.01f*Input.GetTouch(0).deltaPosition.y;
                h = 0.01f*Input.GetTouch(0).deltaPosition.x;
            }
            else if(Application.platform == RuntimePlatform.Android)
            {
                Debug.Log("Android");
                v = 0.01f*Input.GetTouch(0).deltaPosition.y;
                h = 0.01f*Input.GetTouch(0).deltaPosition.x;
            }else
            {
                Debug.Log("other");
                h = horizontalSpeed * Input.GetAxis("Mouse X");
                v = verticalSpeed * Input.GetAxis("Mouse Y");
            }
            if(transform.position.x-v<vertical_min)
            {
                if(transform.position.z+h>horizonal_max)
                {
                    transform.position=new Vector3(vertical_min,transform.position.y,horizonal_max);
                }
                else if(transform.position.z+h<horizonal_min)
                {
                    transform.position=new Vector3(vertical_min,transform.position.y,horizonal_min);
                }
                else
                {
                    transform.position=new Vector3(vertical_min,transform.position.y,transform.position.z+h);
                }
            }
            else if(transform.position.x-v>vertical_max)
            {
                if(transform.position.z+h>horizonal_max)
                {
                    transform.position=new Vector3(vertical_max,transform.position.y,horizonal_max);
                }
                else if(transform.position.z+h<horizonal_min)
                {
                    transform.position=new Vector3(vertical_max,transform.position.y,horizonal_min);
                }
                else
                {
                    transform.position=new Vector3(vertical_max,transform.position.y,transform.position.z+h);
                }
            }
            else
            {
                if(transform.position.z+h>horizonal_max)
                {
                    transform.position=new Vector3(transform.position.x-v,transform.position.y,horizonal_max);
                }
                else if(transform.position.z+h<horizonal_min)
                {
                    transform.position=new Vector3(transform.position.x-v,transform.position.y,horizonal_min);
                }
                else
                {
                    transform.position=new Vector3(transform.position.x-v,transform.position.y,transform.position.z+h);
                }
            }
            //transform.position=new Vector3(transform.position.x-v,transform.position.y,transform.position.z+h);
        }
    }
    public void cameraheightcontrol(float val)
    {
        transform.position=new Vector3(transform.position.x,default_y-val,transform.position.z);
    }
}
