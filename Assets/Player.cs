using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   [SerializeField]
    public static int levelachieved;
    public static int stars;
    public static int crystals;
    public static int skill_1_level;//archer tower
    public static int skill_2_level;//soldier tower
    public static int skill_3_level;//mage tower
    public static int skill_4_level;//canon tower
    public static int skill_5_level;// support soldier
    public static int skill_6_level;//thunder power
    public static int item_1_amount;
    public static int item_2_amount;
    public static int item_3_amount;
    public static int item_4_amount;
    public static bool hero1;
    public static bool hero2;
    public static bool hero3;
    public static int save_NUM;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(save_NUM);
        Debug.Log(levelachieved);
        //DontDestroyOnLoad(transform.gameObject);
    }
    public void SavePlayer(int i)
    {
        SaveSystem.SavePlayer(i);
    }
    public void LoadPlayer(int i)
    {
        Player_data data = SaveSystem.LoadPlayer(i);
        Debug.Log(data);
        if(data!=null)
        {
            levelachieved=data.levelachieved;
            stars=data.stars;
            crystals=data.crystals;
            skill_1_level=data.skill_1_level;
            skill_2_level=data.skill_2_level;
            skill_3_level=data.skill_3_level;
            skill_4_level=data.skill_4_level;
            skill_5_level=data.skill_5_level;
            skill_6_level=data.skill_6_level;
            item_1_amount=data.item_1_amount;
            item_2_amount=data.item_2_amount;
            item_3_amount=data.item_3_amount;
            item_4_amount=data.item_4_amount;
            hero1=data.hero1;
            hero2=data.hero2;
            hero3=data.hero3;
            save_NUM=data.save_NUM;
        }
        
    }
}
