using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class panel_functions : MonoBehaviour
{	
    public GameObject false_palce;
    public GameObject thunder;
    public bool prepare_thunder=false;
    public GameObject soldier;
    public bool prepare_soldier=false;
    public GameObject thunder_button;
    public GameObject thunder_cancel_button;
    public GameObject soldier_button;
    public GameObject soldier_cancel_button;
    public bool thunder_cool_down=false;
    public bool soldier_cool_down=false;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(prepare_thunder)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray,out hit,200,mask))
                {
                    Debug.Log(EventSystem.current.IsPointerOverGameObject());
                    if(EventSystem.current.IsPointerOverGameObject())
                    {
                        Debug.Log("on UI");
                        return;
                    }
                    if(hit.transform.tag=="road")
                    {
                        GameObject newthunder =Instantiate(thunder,hit.point,Quaternion.identity);
                        thunder_cool_down=true;
                        prepare_thunder=false;
                        thunder_button.SetActive(true);
                        thunder_cancel_button.SetActive(false);
                        // transform.position=hit.transform.position;
                        // selectpanel.SetActive(true);
                        // selectedtower=hit.transform.gameObject;
                        // showpanel();
                    }
                    else 
                    {
                        GameObject newfalseplace =Instantiate(false_palce,hit.point,Quaternion.identity);
                        // close_panel();
                        // if(preview)
                        // {
                        //     cancel_preview_next_tower();
                        // }
                        // selectedtower=null;
                    }
                }
            }
        }
        if(prepare_soldier)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray,out hit,200))
                {
                    if(EventSystem.current.IsPointerOverGameObject())
                    {
                        return;
                    }
                    if(hit.transform.tag=="road")
                    {
                        GameObject newthunder =Instantiate(soldier,hit.point,Quaternion.identity);
                        GameObject newthunder1 =Instantiate(soldier,hit.point,Quaternion.identity);
                        soldier_cool_down=true;
                        prepare_soldier=false;
                        soldier_button.SetActive(true);
                        soldier_cancel_button.SetActive(false);
                        // transform.position=hit.transform.position;
                        // selectpanel.SetActive(true);
                        // selectedtower=hit.transform.gameObject;
                        // showpanel();
                    }
                    else 
                    {
                        GameObject newfalseplace =Instantiate(false_palce,hit.point,Quaternion.identity);
                        // close_panel();
                        // if(preview)
                        // {
                        //     cancel_preview_next_tower();
                        // }
                        // selectedtower=null;
                    }
                }
            }
        }
    }
    
    public void test_function()
    {
        Debug.Log("click button");

    }
    public void Spawnthunder()
    {
        prepare_thunder=true;
        thunder_button.SetActive(false);
        thunder_cancel_button.SetActive(true);
    }
    public void CancelSpawnthunder()
    {
        prepare_thunder=false;
        thunder_button.SetActive(true);
        thunder_cancel_button.SetActive(false);
    }
    public void Spawnsoldier()
    {
        prepare_soldier=true;
        soldier_button.SetActive(false);
        soldier_cancel_button.SetActive(true);
    } 
    public void CancelSpawnsoldier()
    {
        prepare_soldier=false;
        soldier_button.SetActive(true);
        soldier_cancel_button.SetActive(false);
    } 
    public void add_health()
    {
        if(Player.item_2_amount>0)
        {
            Player_status.player_health+=5;
            Player.item_1_amount-=1;
        }
        else{}
        SaveSystem.SavePlayer(Player.save_NUM);
    } 
     public void add_gold()
    {
        if(Player.item_2_amount>0)
        {
            Player.item_2_amount-=1;
            Player_status.money+=500;
        }
        else{}
        SaveSystem.SavePlayer(Player.save_NUM);
    } 
	
}
