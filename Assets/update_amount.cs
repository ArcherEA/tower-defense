using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class update_amount : MonoBehaviour
{
     [SerializeField] TextMeshProUGUI m_Object;
     public int Num;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (Num)
        {
            case 1:
                m_Object.text="X"+Player.item_1_amount;
                break;
            case 2:
                m_Object.text="X"+Player.item_2_amount;
                break;
            case 3:
                m_Object.text="X"+Player.item_3_amount;
                break;
            case 4:
                m_Object.text="X"+Player.item_4_amount;
                break;
            case 5:
                m_Object.text="LV."+Player.skill_1_level;
                break;
            case 6:
                m_Object.text="LV."+Player.skill_2_level;
                break;
            case 7:
                m_Object.text="LV."+Player.skill_3_level;
                break;
            case 8:
                m_Object.text="LV."+Player.skill_4_level;
                break;
            case 9:
                m_Object.text="LV."+Player.skill_5_level;
                break;
            case 10:
                m_Object.text="LV."+Player.skill_6_level;
                break;
        }
        
    }
}
