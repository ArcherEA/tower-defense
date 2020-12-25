using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_disable : MonoBehaviour
{
    private float time_cost;
    public float disappear_time;
    // Start is called before the first frame update
    void Awake()
    {
       time_cost=0f;
    }

    // Update is called once per frame
    void Update()
    {
        time_cost+=Time.deltaTime;
        if(time_cost>disappear_time){disable_object();}
    }
    void disable_object()
    {
        time_cost=0f;
        this.gameObject.SetActive(false);
    }
}
