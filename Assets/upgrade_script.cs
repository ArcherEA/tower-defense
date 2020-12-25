using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TD
{
    public class upgrade_script : MonoBehaviour
    {
        public GameObject upgradebutton;
        public game_Manager gm;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(gm.selectedtower!=null&&gm.selectedtower.GetComponent<tower>().next_tower!=null)
            {
                upgradebutton.SetActive(true);
            }
            else if(gm.selectedtower!=null)
            {
                upgradebutton.SetActive(false);
            }
        }
    }
}
