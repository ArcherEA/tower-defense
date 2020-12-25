using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TD
{
    public class spawn_control : MonoBehaviour
    {
            // public float cooldown=30f;
            // private float time_cost=0f;
            public wave_spawner WS;
            public Button SPAWNbutton;
            // public Image cooldownimage;

            // Start is called before the first frame update
            void Start()
            {
                
            }

            // Update is called once per frame
            void Update()
            {
                if(wave_spawner.finish_spawn)
                {
                    SPAWNbutton.interactable = true;
                }
                else
                {
                    SPAWNbutton.interactable = false;
                }
            }
            public void spawn()
            {
                WS.start=true;
                WS.countdown=0f;
            }
            
    }
}
