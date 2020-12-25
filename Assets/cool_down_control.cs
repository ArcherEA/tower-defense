using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TD
{
    

    public class cool_down_control : MonoBehaviour
    {
        public float cooldown=30f;
        private float time_cost=0f;
        public panel_functions pF;
        public Button skillbutton;
        public Image cooldownimage;
        public bool skill1=true;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(skill1)
            {
                thundercooldown();
            }
            else
            {
                soldiercooldown();
            }
        }
        void soldiercooldown()
        {
            if(pF.soldier_cool_down)
            {
                time_cost+=Time.deltaTime;
                skillbutton.interactable = false;
                cooldownimage.fillAmount=(cooldown-time_cost)/cooldown;
                if(time_cost>cooldown)
                {
                    pF.soldier_cool_down=false;
                }
            }
            else
            {
                time_cost=0f;
                skillbutton.interactable = true;
                cooldownimage.fillAmount=0f;
            }
        }
        void thundercooldown()
        {
            if(pF.thunder_cool_down)
            {
                time_cost+=Time.deltaTime;
                skillbutton.interactable = false;
                cooldownimage.fillAmount=(cooldown-time_cost)/cooldown;
                if(time_cost>cooldown)
                {
                    pF.thunder_cool_down=false;
                }
            }
            else
            {
                time_cost=0f;
                skillbutton.interactable = true;
                cooldownimage.fillAmount=0f;
            }
        }
    }
}
