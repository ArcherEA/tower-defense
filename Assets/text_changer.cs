using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace TD
{
    public class text_changer : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI m_Object;
        public GameObject Gamemanager;
        public int option;
        // Start is called before the first frame update
        void Start()
        {
            //m_Object.text=Player_status.player_health.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            if(Gamemanager.GetComponent<game_Manager>().selectedtower!=null)
            {
                switch(option)
                {
                    case 1:
                        m_Object.text="$"+Gamemanager.GetComponent<game_Manager>().selectedtower.GetComponent<build_point>().soldier_cost;
                        break;
                    case 2:
                        m_Object.text="$"+Gamemanager.GetComponent<game_Manager>().selectedtower.GetComponent<build_point>().archer_cost;
                        break;
                    case 3:
                        m_Object.text="$"+Gamemanager.GetComponent<game_Manager>().selectedtower.GetComponent<build_point>().mage_cost;
                        break;
                    case 4:
                        m_Object.text="$"+Gamemanager.GetComponent<game_Manager>().selectedtower.GetComponent<build_point>().canon_cost;
                        break;
                    case 5:
                        m_Object.text="$"+Gamemanager.GetComponent<game_Manager>().selectedtower.GetComponent<tower>().levelup_cost;
                        break;
                    case 6:
                        m_Object.text="$"+Gamemanager.GetComponent<game_Manager>().selectedtower.GetComponent<tower>().value;
                        break;
                }
            }
            //m_Object.text=Player_status.player_health.ToString();
        }
    }
}
