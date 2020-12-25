using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_controller : MonoBehaviour
{
     private ParticleSystem ps;
    // Start is called before the first frame update
    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.isPlaying){return;}
        else
        {

            Destroy(this.gameObject);
        }
    }
}
