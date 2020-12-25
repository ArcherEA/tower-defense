using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TD
{
    

    public class button_inactive_manager : MonoBehaviour
    {
        public GameObject button;
        public GameObject gamemanager;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
            if(gamemanager.GetComponent<game_Manager>().selectedtower.GetComponent<tower>().levelup_cost>Player_status.money)
            {
                button.SetActive(false);
            }
            else{button.SetActive(true);}
        }
    }
}
