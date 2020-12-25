using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player_data 
{
    public int levelachieved;
    public int stars;
    public int crystals;
    public int skill_1_level;
    public int skill_2_level;
    public int skill_3_level;
    public int skill_4_level;
    public int skill_5_level;
    public int skill_6_level;
    public int item_1_amount;
    public int item_2_amount;
    public int item_3_amount;
    public int item_4_amount;
    public bool hero1;
    public bool hero2;
    public bool hero3;
    public int save_NUM;

    public Player_data()
    {
        levelachieved=Player.levelachieved;
        stars=Player.stars;
        crystals=Player.crystals;
        skill_1_level=Player.skill_1_level;
        skill_2_level=Player.skill_2_level;
        skill_3_level=Player.skill_3_level;
        skill_4_level=Player.skill_4_level;
        skill_5_level=Player.skill_5_level;
        skill_6_level=Player.skill_6_level;
        item_1_amount=Player.item_1_amount;
        item_2_amount=Player.item_2_amount;
        item_3_amount=Player.item_3_amount;
        item_4_amount=Player.item_4_amount;
        hero1=Player.hero1;
        hero2=Player.hero2;
        hero3=Player.hero3;
        save_NUM=Player.save_NUM;
    }
}
