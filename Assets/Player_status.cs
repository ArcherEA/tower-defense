using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_status : MonoBehaviour
{
    public static int player_health;
    public static int money;
    public int start_money;
    public int start_health;

    // Start is called before the first frame update
    void Start()
    {
        player_health=start_health;
        money=start_money;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}