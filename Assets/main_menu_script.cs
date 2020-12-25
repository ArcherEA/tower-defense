using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class main_menu_script : MonoBehaviour
{
    public GameObject mainpanel;
    public GameObject intropanel;
    public GameObject shoppanel;
    public GameObject researchpanel;
    public GameObject heropanel;
    public GameObject settingpanel;
    public GameObject research_buy_button;
    public GameObject level1_button;
    public GameObject level2_button;
    public GameObject level3_button;
    public AudioSource click;
    public AudioSource main_bgm;
    public AudioSource shop_bgm;
    public Animator transition;
    public float transitionTime=1f;
    //public static GameObject selectedtalent;
    //[SerializeField] TextMeshProUGUI m_Object;
    [SerializeField] TextMeshProUGUI intro_text;
    [SerializeField] TextMeshProUGUI shop_textobject;
    [SerializeField] TextMeshProUGUI research_textobject;
    [SerializeField] TextMeshProUGUI research_text1;
    // private string lv1info="";
    // private string lv2info=""; 
    // private string lv3info="";
    public int skill_num;
    private int level;
    public void Update()
    {
        switch(Player.levelachieved)
        {
            case 0:level1_button.SetActive(true);level2_button.SetActive(false);level3_button.SetActive(false);
            break;
            case 1:level1_button.SetActive(true);level2_button.SetActive(true);level3_button.SetActive(false);
            break;
            case 2:level1_button.SetActive(true);level2_button.SetActive(true);level3_button.SetActive(true);
            break;
            case 3:level1_button.SetActive(true);level2_button.SetActive(true);level3_button.SetActive(true);
            break;

        }
    }
    public void QuitGame(){
        Debug.Log("QUIT!");
        Application.Quit();
    }
   public void ADD_star()
   {
       if(Player.stars<300)
       {
            Player.stars+=10;
       }
       else
       {
           Player.stars=300;
       }
       Debug.Log(Player.save_NUM);
       SaveSystem.SavePlayer(Player.save_NUM);
   }
   public void ADD_crystal()
   {
       if(Player.crystals<900000)
       {
            Player.crystals+=1000;
       }
       else
       {
           Player.crystals=900000;
       }
        Debug.Log(Player.save_NUM);
       SaveSystem.SavePlayer(Player.save_NUM);
   }
    public void Load_level()
    {
        StartCoroutine(Loadscenewithtransition());
    }
    IEnumerator Loadscenewithtransition()
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(level+1);
    }
    // public void Load_lv2()
    // {
    //     SceneManager.LoadScene(3);
    // }
    // public void Load_lv3()
    // {
    //     SceneManager.LoadScene(4);
    // }
    public void show_introductionpanel1()
    {
        level=1;
        intro_text.text="Task intriduction:\nlevel 1:\nThe army of evil dwarves opened the portal to invade our city, we need to stop them\nwave:4";
        intropanel.SetActive(true);
        //intro_text.text="level 1:\n7 waves";
        //m_Object.text=lv1info;
    }
    public void show_introductionpanel2()
    {
        level=2;
        intropanel.SetActive(true);
        intro_text.text="Task intriduction:\nlevel 1:\nAlthough we temporarily repelled the enemy, the enemy’s reinforcements will immediately join the battle.\nwave:5";
        //m_Object.text=lv2info;
    }
    public void show_introductionpanel3()
    {
        level=3;
        intropanel.SetActive(true);
        intro_text.text="Task intriduction:\nlevel 1:\nThis is the last wave of enemy reinforcements. Hold on and defend our city.\nwaves:7";
        //m_Object.text=lv3info;
    }
    public void shop_return_button()
    {
        main_bgm.Play();
        shop_bgm.Stop();
        intropanel.SetActive(false);
        shoppanel.SetActive(false);
        researchpanel.SetActive(false);
        heropanel.SetActive(false);
        settingpanel.SetActive(false);
        mainpanel.SetActive(true);
    }
    public void return_button()
    {
        intropanel.SetActive(false);
        shoppanel.SetActive(false);
        researchpanel.SetActive(false);
        heropanel.SetActive(false);
        settingpanel.SetActive(false);
        mainpanel.SetActive(true);
    }
    public void open_shoppanel()
    {
        shop_bgm.Play();
        main_bgm.Stop();
        shoppanel.SetActive(true);
    }
    public void open_researchpanel()
    {
        researchpanel.SetActive(true);
    }
    public void open_heropanel()
    {
        heropanel.SetActive(true);
    }
    public void open_settingpanel()
    {
        settingpanel.SetActive(true);
    }
    public void buy_potion()
    {
        if(Player.crystals>100)
        {
            shop_textobject.text="thank you for purchase";
            Player.crystals-=100;
            Player.item_1_amount+=1;
        }
        else
        {
            shop_textobject.text="sorry, you dont have enough money";
        }
        SaveSystem.SavePlayer(Player.save_NUM);
    }
    public void buy_coinbag()
    {
        if(Player.crystals>200)
        {
            shop_textobject.text="thank you for purchase";
            Player.crystals-=200;
            Player.item_2_amount+=1;
        }
        else
        {
            shop_textobject.text="sorry, you dont have enough money";
        }
        SaveSystem.SavePlayer(Player.save_NUM);
    }
    public void buy_missile()
    {
        if(Player.crystals>300)
        {
            shop_textobject.text="thank you for purchase";
            Player.crystals-=300;
            Player.item_3_amount+=1;
        }
        else
        {
            shop_textobject.text="sorry, you dont have enough money";
        }
        SaveSystem.SavePlayer(Player.save_NUM);
    }
    public void buy_staff()
    {
        if(Player.crystals>400)
        {
            shop_textobject.text="thank you for purchase";
            Player.crystals-=400;
            Player.item_4_amount+=1;
        }
        else
        {
            shop_textobject.text="sorry, you dont have enough money";
        }
        SaveSystem.SavePlayer(Player.save_NUM);
    }
    public void buy_skill()
    {
        switch (skill_num)
        {
            case 0:research_text1.text="Please choose one skill";
            break;
            case 1:
            switch(Player.skill_1_level)
            {
                case 0:
                if(Player.stars>=1)
                {
                    Player.skill_1_level+=1;
                    Player.stars-=1;
                    research_text1.text="success";
                }else
                {
                    research_text1.text="sorry,you don't have enough stars";
                }
                break;
                case 1:
                if(Player.stars>=2)
                {
                    Player.skill_1_level+=1;
                    Player.stars-=2;
                    research_text1.text="success";
                }else
                {
                    research_text1.text="sorry,you don't have enough stars";
                }
                break;
                case 2:
                 if(Player.stars>=3)
                {
                    Player.skill_1_level+=1;
                    Player.stars-=3;
                    research_text1.text="success";
                }else
                {
                    research_text1.text="sorry,you don't have enough stars";
                }
                break;
                case 3:research_text1.text="Already reach max level!";
                break;
            }
            break;
            case 2:
            switch(Player.skill_2_level)
            {
                case 0:
                if(Player.stars>=1)
                {
                    Player.skill_2_level+=1;
                    Player.stars-=1;
                    research_text1.text="success";
                }else
                {
                    research_text1.text="sorry,you don't have enough stars";
                }
                break;
                case 1:
                if(Player.stars>=2)
                {
                    Player.skill_2_level+=1;
                    Player.stars-=2;
                    research_text1.text="success";
                }else
                {
                    research_text1.text="sorry,you don't have enough stars";
                }
                break;
                case 2:
                 if(Player.stars>=3)
                {
                    Player.skill_2_level+=1;
                    Player.stars-=3;
                    research_text1.text="success";
                }else
                {
                    research_text1.text="sorry,you don't have enough stars";
                }
                break;
                case 3:research_text1.text="Already reach max level!";
                break;
            }
            break;
            case 3:
            switch(Player.skill_3_level)
            {
                case 0:
                if(Player.stars>=1)
                {
                    Player.skill_3_level+=1;
                    Player.stars-=1;
                    research_text1.text="success";
                }else
                {
                    research_text1.text="sorry,you don't have enough stars";
                }
                break;
                case 1:
                if(Player.stars>=2)
                {
                    Player.skill_3_level+=1;
                    Player.stars-=2;
                    research_text1.text="success";
                }else
                {
                    research_text1.text="sorry,you don't have enough stars";
                }
                break;
                case 2:
                 if(Player.stars>=3)
                {
                    Player.skill_3_level+=1;
                    Player.stars-=3;
                    research_text1.text="success";
                }else
                {
                    research_text1.text="sorry,you don't have enough stars";
                }
                break;
                case 3:research_text1.text="Already reach max level!";
                break;
            }
            break;
            case 4:
            switch(Player.skill_4_level)
            {
                case 0:
                if(Player.stars>=1)
                {
                    Player.skill_4_level+=1;
                    Player.stars-=1;
                    research_text1.text="success";
                }else
                {
                    research_text1.text="sorry,you don't have enough stars";
                }
                break;
                case 1:
                if(Player.stars>=2)
                {
                    Player.skill_4_level+=1;
                    Player.stars-=2;
                    research_text1.text="success";
                }else
                {
                    research_text1.text="sorry,you don't have enough stars";
                }
                break;
                case 2:
                 if(Player.stars>=3)
                {
                    Player.skill_4_level+=1;
                    Player.stars-=3;
                    research_text1.text="success";
                }else
                {
                    research_text1.text="sorry,you don't have enough stars";
                }
                break;
                case 3:research_text1.text="Already reach max level!";
                break;
            }
            break;
            case 5:
            switch(Player.skill_5_level)
            {
                case 0:
                if(Player.stars>=1)
                {
                    Player.skill_5_level+=1;
                    Player.stars-=1;
                    research_text1.text="success";
                }else
                {
                    research_text1.text="sorry,you don't have enough stars";
                }
                break;
                case 1:
                if(Player.stars>=2)
                {
                    Player.skill_5_level+=1;
                    Player.stars-=2;
                    research_text1.text="success";
                }else
                {
                    research_text1.text="sorry,you don't have enough stars";
                }
                break;
                case 2:
                 if(Player.stars>=3)
                {
                    Player.skill_5_level+=1;
                    Player.stars-=3;
                    research_text1.text="success";
                }else
                {
                    research_text1.text="sorry,you don't have enough stars";
                }
                break;
                case 3:research_text1.text="Already reach max level!";
                break;
            }
            break;
            case 6:
            switch(Player.skill_6_level)
            {
                case 0:
                if(Player.stars>=1)
                {
                    Player.skill_6_level+=1;
                    Player.stars-=1;
                    research_text1.text="success";
                }else
                {
                    research_text1.text="sorry,you don't have enough stars";
                }
                break;
                case 1:
                if(Player.stars>=2)
                {
                    Player.skill_6_level+=1;
                    Player.stars-=2;
                    research_text1.text="success";
                }else
                {
                    research_text1.text="sorry,you don't have enough stars";
                }
                break;
                case 2:
                 if(Player.stars>=3)
                {
                    Player.skill_6_level+=1;
                    Player.stars-=3;
                    research_text1.text="success";
                }else
                {
                    research_text1.text="sorry,you don't have enough stars";
                }
                break;
                case 3:research_text1.text="Already reach max level!";
                break;
            }
            break;
        }
        SaveSystem.SavePlayer(Player.save_NUM);
    }
    public void show_buy_button1()
    {
        skill_num=1;
        switch(Player.skill_1_level)
        {
            case 0: research_textobject.text="Skill introduction:\nthis skill will increase your archer tower ability\nattack damage:+0%\nattack speed:+0%";
                research_text1.text="upgrade cost: 1 star";
            break;
            case 1: research_textobject.text="Skill introduction:\nthis skill will increase your archer tower ability\nattack damage:+150%\nattack speed:+100%";
            research_text1.text="upgrade cost: 2 star";
            break;
            case 2: research_textobject.text="Skill introduction:\nthis skill will increase your archer tower ability\nattack damage:+200%\nattack speed:+200%";
            research_text1.text="upgrade cost: 3 star";
            break;
            case 3: research_textobject.text="Skill introduction:\nthis skill will increase your archer tower ability\nattack damage:+300%\nattack speed:+300%";
            research_text1.text="reach max level";
            break;
        }
        research_buy_button.SetActive(true);
    }
    public void show_buy_button2()
    {
        skill_num=2;
        switch(Player.skill_2_level)
        {
            case 0: research_textobject.text="Skill introduction:\nthis skill will increase your soldier tower ability\nattack damage:+0\nattack speed:+0%";
            research_text1.text="upgrade cost: 1 star";
            break;
            case 1: research_textobject.text="Skill introduction:\nthis skill will increase your soldier tower ability\nattack damage:+150%\nattack speed:+10%";
            research_text1.text="upgrade cost: 2 star";
            break;
            case 2: research_textobject.text="Skill introduction:\nthis skill will increase your soldier tower ability\nattack damage:+200%\nattack speed:+20%";
            research_text1.text="upgrade cost: 3 star";
            break;
            case 3: research_textobject.text="Skill introduction:\nthis skill will increase your soldier tower ability\nattack damage:+300%\nattack speed:+30%";
            research_text1.text="reach max level";
            break;
        }
        research_buy_button.SetActive(true);
    }
    public void show_buy_button3()
    {
        skill_num=3;
        switch(Player.skill_3_level)
        {
            case 0: research_textobject.text="Skill introduction:\nthis skill will increase your mage tower ability\nability power:+0\nattack speed:+0%\n";
            research_text1.text="upgrade cost: 1 star";
            break;
            case 1: research_textobject.text="Skill introduction:\nthis skill will increase your mage tower ability\nability power:+150%\nattack speed:+100%\n";
            research_text1.text="upgrade cost: 2 star";
            break;
            case 2: research_textobject.text="Skill introduction:\nthis skill will increase your mage tower ability\nability power:+200%\nattack speed:+200%\n";
            research_text1.text="upgrade cost: 3 star";
            break;
            case 3: research_textobject.text="Skill introduction:\nthis skill will increase your mage tower ability\nability power:+300%\nattack speed:+300%\n";
            research_text1.text="reach max level";
            break;
        }
        research_buy_button.SetActive(true);
    }
    public void show_buy_button4()
    {
        skill_num=4;
        switch(Player.skill_4_level)
        {
            case 0: research_textobject.text="Skill introduction:\nthis skill will increase your canon tower ability\ndamage:+0\nloading time:-0\n";
            research_text1.text="upgrade cost: 1 star";
            break;
            case 1: research_textobject.text="Skill introduction:\nthis skill will increase your canon tower ability\ndamage:+150%\nloading time:-20%\n";
            research_text1.text="upgrade cost: 2 star";
            break;
            case 2: research_textobject.text="Skill introduction:\nthis skill will increase your canon tower ability\ndamage:+200%\nloading time:-40%\n";
            research_text1.text="upgrade cost: 3 star";
            break;
            case 3: research_textobject.text="Skill introduction:\nthis skill will increase your canon tower ability\ndamage:+30%0\nloading time:-70%\n";
            research_text1.text="reach max level";
            break;
        }
        research_buy_button.SetActive(true);
    }
    public void show_buy_button5()
    {
        skill_num=5;
        switch(Player.skill_5_level)
        {
            case 0: research_textobject.text="Skill introduction:\nsupport soldier ability:\nattack damage:+0\nattack speed:+0%\narmor:+0 magic resist:+0\nhealth:+0";
            research_text1.text="upgrade cost: 1 star";
            break;
            case 1: research_textobject.text="Skill introduction:\nsupport soldier ability:\nattack damage:+150%\nattack speed:+10%\narmor:+10magic resist:+10\nhealth:+200%";
            research_text1.text="upgrade cost: 2 star";
            break;
            case 2: research_textobject.text="Skill introduction:\nsupport soldier ability:\nattack damage:+200%\nattack speed:+20%\narmor:+20magic resist:+20\nhealth:+300%";
            research_text1.text="upgrade cost: 3 star";
            break;
            case 3: research_textobject.text="Skill introduction:\nsupport soldier ability:\nattack damage:+300%\nattack speed:+30%\narmor:+30magic resist:+30\nhealth:+400%";
            research_text1.text="reach max level";
            break;
        }
        research_buy_button.SetActive(true);
    }
    public void show_buy_button6()
    {
        skill_num=6;
        switch(Player.skill_6_level)
        {
            case 0: research_textobject.text="Skill introduction:\nthis skill will increase your thunder skill ability\ndamage:+0\nLightning interval:1.2s";
            research_text1.text="upgrade cost: 1 star";
            break;
            case 1: research_textobject.text="Skill introduction:\nthis skill will increase your thunder skill ability\ndamage:+150%\nLightning interval:1s";
            research_text1.text="upgrade cost: 2 star";
            break;
            case 2: research_textobject.text="Skill introduction:\nthis skill will increase your thunder skill ability\ndamage:+200%\nLightning interval:0.5s";
            research_text1.text="upgrade cost: 3 star";
            break;
            case 3: research_textobject.text="Skill introduction:\nthis skill will increase your thunder skill ability\ndamage:+300%\nLightning interval:0.2s";
            research_text1.text="reach max level";
            break;
        }
        research_buy_button.SetActive(true);
    }
    public void reset_skill()
    {
        for(;Player.skill_6_level>0;Player.skill_6_level--)
        {
            Player.stars+=Player.skill_6_level;
        }
        for(;Player.skill_5_level>0;Player.skill_5_level--)
        {
            Player.stars+=Player.skill_5_level;
        }
        for(;Player.skill_4_level>0;Player.skill_4_level--)
        {
            Player.stars+=Player.skill_4_level;
        }
        for(;Player.skill_3_level>0;Player.skill_3_level--)
        {
            Player.stars+=Player.skill_3_level;
        }
        for(;Player.skill_2_level>0;Player.skill_2_level--)
        {
            Player.stars+=Player.skill_2_level;
        }
        for(;Player.skill_1_level>0;Player.skill_1_level--)
        {
            Player.stars+=Player.skill_1_level;
        }
        research_textobject.text="click on left icon to upgrade your skill";
        research_text1.text="reset succes";
        SaveSystem.SavePlayer(Player.save_NUM);
    }
    public void click_button()
    {
        click.Play();
    } 
}
