using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class button_info : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    [SerializeField] TextMeshProUGUI m_Object;
    //[SerializeField] TextMeshProUGUI research_text1;
    public int num;
    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (num)
        {
            case 1: m_Object.text="use this potion to increase your health while in battle";
            break;
            case 2: m_Object.text="use this coin bag to increase your gold while in battle";
            break;
            case 3: m_Object.text="use this missile to explode your enemy while in battle";
            break;
            case 4: m_Object.text="use this staff to freeze your enemy while in battle";
            break;
            // case 5:
            //     //main_menu_script.selectedtalent=this.gameObject;
            //     switch(Player.skill_1_level)
            //     {
            //        case 0: m_Object.text="Skill introduction:\nthis skill will increase your archer tower ability\nattack damage:+0\nattack speed:+0%";
            //             research_text1.text="upgrade cost: 1 star";
            //        break;
            //        case 1: m_Object.text="Skill introduction:\nthis skill will increase your archer tower ability\nattack damage:+0\nattack speed:+0%";
            //         research_text1.text="upgrade cost: 2 star";
            //        break;
            //        case 2: m_Object.text="Skill introduction:\nthis skill will increase your archer tower ability\nattack damage:+0\nattack speed:+0%";
            //         research_text1.text="upgrade cost: 3 star";
            //        break;
            //        case 3: m_Object.text="Skill introduction:\nthis skill will increase your archer tower ability\nattack damage:+0\nattack speed:+0%";
            //         research_text1.text="reach max level";
            //        break;
            //     }
                
            // break;
            // case 6: 
            //     switch(Player.skill_2_level)
            //     {
            //        case 0: m_Object.text="Skill introduction:\nthis skill will increase your soldier tower ability\nattack damage:+0\nattack speed:+0%\narmor:+0\nmagic resist:+0\nhealth:+0";
            //        research_text1.text="upgrade cost: 1 star";
            //        break;
            //        case 1: m_Object.text="Skill introduction:\nthis skill will increase your soldier tower ability\nattack damage:+0\nattack speed:+0%\narmor:+0\nmagic resist:+0\nhealth:+0";
            //        research_text1.text="upgrade cost: 2 star";
            //        break;
            //        case 2: m_Object.text="Skill introduction:\nthis skill will increase your soldier tower ability\nattack damage:+0\nattack speed:+0%\narmor:+0\nmagic resist:+0\nhealth:+0";
            //        research_text1.text="upgrade cost: 3 star";
            //        break;
            //        case 3: m_Object.text="Skill introduction:\nthis skill will increase your soldier tower ability\nattack damage:+0\nattack speed:+0%\narmor:+0\nmagic resist:+0\nhealth:+0";
            //        research_text1.text="reach max level";
            //        break;
            //     }
            // break;
            // case 7: 
            //     switch(Player.skill_3_level)
            //     {
            //        case 0: m_Object.text="Skill introduction:\nthis skill will increase your mage tower ability\nability power:+0\nattack speed:+0%\n";
            //        research_text1.text="upgrade cost: 1 star";
            //        break;
            //        case 1: m_Object.text="Skill introduction:\nthis skill will increase your mage tower ability\nability power:+0\nattack speed:+0%\n";
            //        research_text1.text="upgrade cost: 2 star";
            //        break;
            //        case 2: m_Object.text="Skill introduction:\nthis skill will increase your mage tower ability\nability power:+0\nattack speed:+0%\n";
            //        research_text1.text="upgrade cost: 3 star";
            //        break;
            //        case 3: m_Object.text="Skill introduction:\nthis skill will increase your mage tower ability\nability power:+0\nattack speed:+0%\n";
            //        research_text1.text="reach max level";
            //        break;
            //     }
            // break;
            // case 8: 
            //     switch(Player.skill_4_level)
            //     {
            //        case 0: m_Object.text="Skill introduction:\nthis skill will increase your canon tower ability\ndamage:+0\ndamage range:+0\n";
            //        research_text1.text="upgrade cost: 1 star";
            //        break;
            //        case 1: m_Object.text="Skill introduction:\nthis skill will increase your canon tower ability\ndamage:+0\ndamage range:+0\n";
            //        research_text1.text="upgrade cost: 2 star";
            //        break;
            //        case 2: m_Object.text="Skill introduction:\nthis skill will increase your canon tower ability\ndamage:+0\ndamage range:+0\n";
            //        research_text1.text="upgrade cost: 3 star";
            //        break;
            //        case 3: m_Object.text="Skill introduction:\nthis skill will increase your canon tower ability\ndamage:+0\ndamage range:+0\n";
            //        research_text1.text="reach max level";
            //        break;
            //     }
            // break;
            // case 9: 
            //     switch(Player.skill_5_level)
            //     {
            //        case 0: m_Object.text="Skill introduction:\nthis skill will increase your support soldier ability\nattack damage:+0\nattack speed:+0%\narmor:+0\nmagic resist:+0\nhealth:+0";
            //        research_text1.text="upgrade cost: 1 star";
            //        break;
            //        case 1: m_Object.text="Skill introduction:\nthis skill will increase your support soldier ability\nattack damage:+0\nattack speed:+0%\narmor:+0\nmagic resist:+0\nhealth:+0";
            //        research_text1.text="upgrade cost: 2 star";
            //        break;
            //        case 2: m_Object.text="Skill introduction:\nthis skill will increase your support soldier ability\nattack damage:+0\nattack speed:+0%\narmor:+0\nmagic resist:+0\nhealth:+0";
            //        research_text1.text="upgrade cost: 3 star";
            //        break;
            //        case 3: m_Object.text="Skill introduction:\nthis skill will increase your support soldier ability\nattack damage:+0\nattack speed:+0%\narmor:+0\nmagic resist:+0\nhealth:+0";
            //        research_text1.text="reach max level";
            //        break;
            //     }
            // break;
            // case 10: 
            //    switch(Player.skill_6_level)
            //     {
            //        case 0: m_Object.text="Skill introduction:\nthis skill will increase your thunder skill ability\ndamage:+0\ndamage range:+0\nLightning interval:1s";
            //        research_text1.text="upgrade cost: 1 star";
            //        break;
            //        case 1: m_Object.text="Skill introduction:\nthis skill will increase your thunder skill ability\ndamage:+0\ndamage range:+0\nLightning interval:1s";
            //        research_text1.text="upgrade cost: 2 star";
            //        break;
            //        case 2: m_Object.text="Skill introduction:\nthis skill will increase your thunder skill ability\ndamage:+0\ndamage range:+0\nLightning interval:1s";
            //        research_text1.text="upgrade cost: 3 star";
            //        break;
            //        case 3: m_Object.text="Skill introduction:\nthis skill will increase your thunder skill ability\ndamage:+0\ndamage range:+0\nLightning interval:1s";
            //        research_text1.text="reach max level";
            //        break;
            //     }
            // break;
           
            
        }

        //do your stuff when highlighted
    }
    public void OnSelect(BaseEventData eventData)
    {
        // if()
        // m_Object.text="thank you";
        //do your stuff when selected
    }
}