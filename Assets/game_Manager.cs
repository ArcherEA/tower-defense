using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
namespace TD
{
    

    public class game_Manager : MonoBehaviour
    {
        public GameObject selectpanel;
        public GameObject selectedtower;
        public GameObject subpanel_1;//tower select 
        public GameObject subpanel_2;//confirm panel
        public GameObject subpanel_3;//soldier panel
        public GameObject subpanel_4;//(canon archer mage panel)
        public GameObject pause_panel;
        public GameObject losepanel;
        public GameObject winpanel;
        public GameObject BP;
        private bool preview=false;
        private bool speedup=false;
        private bool movesoldierdestination=false;
        public GameObject false_palce;
        public GameObject flag;
        public int level_no;
        public AudioSource click;
        public Animator transition;
        public float transitionTime=1f;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {   
            if(Player_status.player_health<=0)
            {
                losegame();
                this.enabled=false;
            }
            if(wave_spawner.win)
            {
                wingame();
                
                SaveSystem.SavePlayer(Player.save_NUM);
                this.enabled=false;
            }
            // if(wave_spawner.cur_wave==wave_spawner.maximum_wave&&wave_spawner.finish_spawn==false&&wave_spawner.active_enemy_amount==0)
            // {
            //     wingame();
            // }
            if(movesoldierdestination)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if(Physics.Raycast(ray,out hit,200))
                    {
						if(Application.platform == RuntimePlatform.IPhonePlayer)
						{
							if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
							{
								if (EventSystem.current.IsPointerOverGameObject (Input.GetTouch (0).fingerId))
								{
									movesoldierdestination=false;
									//Debug.Log("on UI");
									return;
								}
							}
						}
						else if(Application.platform == RuntimePlatform.Android)
						{
							if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
							{
								if (EventSystem.current.IsPointerOverGameObject (Input.GetTouch (0).fingerId))
								{
									movesoldierdestination=false;
									//Debug.Log("on UI");
									return;
								}
							}
						}
						else 
						{
							if(EventSystem.current.IsPointerOverGameObject())
							{
								movesoldierdestination=false;
								//Debug.Log("on UI");
								return;
							}
						}

                        if(hit.transform.tag=="road")
                        {   
                            if(Vector3.Distance(hit.point,selectedtower.transform.position)<selectedtower.GetComponent<tower>().range)
                            {
                                GameObject newflag =Instantiate(flag,hit.point,Quaternion.identity);
                                selectedtower.GetComponent<soldier_tower_manager>().destination.transform.position=hit.point;
                                selectedtower.GetComponent<tower>().closerange();
                                movesoldierdestination=false;
                            }
                            else
                            {
                                GameObject newfalseplace =Instantiate(false_palce,hit.point,Quaternion.identity);
                            }
                        }
                        else
                        {
                            GameObject newfalseplace =Instantiate(false_palce,hit.point,Quaternion.identity);
                            
                        }
                    }
                }
            }
            else
            {
                if(Input.GetMouseButtonDown(0))
                {
                    if(Application.platform == RuntimePlatform.IPhonePlayer)
						{
							if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
							{
								if (EventSystem.current.IsPointerOverGameObject (Input.GetTouch (0).fingerId))
								{
									
									return;
								}
							}
						}
						else if(Application.platform == RuntimePlatform.Android)
						{
							if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
							{
								if (EventSystem.current.IsPointerOverGameObject (Input.GetTouch (0).fingerId))
								{
									
									return;
								}
							}
						}
						else 
						{
							if(EventSystem.current.IsPointerOverGameObject())
							{
								
								return;
							}
						}
                    // if(EventSystem.current.IsPointerOverGameObject())
                    // {
                    //     return;
                    // }
                    Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if(Physics.Raycast(ray,out hit,200))
                    {
                        //Debug.Log(hit.transform.gameObject);
                        if(hit.transform.tag=="Tower")
                        {
                            if(selectedtower!=null)
                            {
                                selectedtower.GetComponent<tower>().closerange();
                                cancel_preview_next_tower();
                            }
                            transform.position=hit.transform.position;
                            selectpanel.SetActive(true);
                            selectedtower=hit.transform.gameObject;
                            selectedtower.GetComponent<tower>().showrange();
                            showpanel();
                        }
                        else if(Application.platform == RuntimePlatform.IPhonePlayer)
						{
							if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
							{
								if (EventSystem.current.IsPointerOverGameObject (Input.GetTouch (0).fingerId)==false)
								{
									close_panel();
                                    if(preview)
                                    {
                                        cancel_preview_next_tower();
                                    }
                                    if(selectedtower!=null){selectedtower.GetComponent<tower>().closerange();}
                                    selectedtower=null;
								}
							}
						}
						else if(Application.platform == RuntimePlatform.Android)
						{
							if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
							{
								if (EventSystem.current.IsPointerOverGameObject (Input.GetTouch (0).fingerId)==false)
								{
									close_panel();
                                    if(preview)
                                    {
                                        cancel_preview_next_tower();
                                    }
                                    if(selectedtower!=null){selectedtower.GetComponent<tower>().closerange();}
                                    selectedtower=null;
								}
							}
						}
						else 
						{
							if(EventSystem.current.IsPointerOverGameObject()==false)
							{
								close_panel();
                                if(preview)
                                {
                                    cancel_preview_next_tower();
                                }
                                if(selectedtower!=null){selectedtower.GetComponent<tower>().closerange();}
                                selectedtower=null;
							}
						}
                        // else if(EventSystem.current.IsPointerOverGameObject()==false)
                        // {
                        //     close_panel();
                        //     if(preview)
                        //     {
                        //         cancel_preview_next_tower();
                        //     }
                        //     if(selectedtower!=null){selectedtower.GetComponent<tower>().closerange();}
                        //     selectedtower=null;
                        // }
                        // else 
                        // {
                        //     if(preview)
                        //     {
                        //         cancel_preview_next_tower();
                        //     }
                        //     selectedtower=null;
                        // }
                    }
                }
            }
        }
        void losegame()
        {
            //wave_spawner.tim = 0f;
            losepanel.SetActive(true);
        }
        void wingame()
        {
            //wave_spawner.tim = 0f;
            Player.levelachieved=level_no;
            SaveSystem.SavePlayer(Player.save_NUM);
            winpanel.SetActive(true);
        }
        void showpanel()
        {
            close_panel();
            if(selectedtower.GetComponent<tower>().type==0)
            {
                subpanel_1.SetActive(true);
            }
            else if(selectedtower.GetComponent<tower>().type==1)
            {
                subpanel_3.SetActive(true);
            }
            else if(selectedtower.GetComponent<tower>().type==2)
            {
                subpanel_4.SetActive(true);
            }
        }
        public void return_main()
        {
            Debug.Log("return main");
            wave_spawner.tim = 1f;
            SaveSystem.SavePlayer(Player.save_NUM);
            losepanel.SetActive(false);
            winpanel.SetActive(false);
            StartCoroutine(Loadscenewithtransition());
        }
         IEnumerator Loadscenewithtransition()
        {
            Debug.Log("load scene");
            transition.SetTrigger("start");
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene(1);
        }
        public void cancel_button()
        {
            close_panel();
            cancel_preview_next_tower();
        }
        public void preview_tower()
        {
            if(selectedtower.GetComponent<tower>().next_tower!=null)
            {
                Debug.Log("upgrade");
                preview=true;
                selectedtower.GetComponent<tower>().preview_next_tower();
                close_panel();
                subpanel_2.SetActive(true);
            }
        }
        public void cancel_preview_next_tower()
        {
            if(selectedtower!=null)
            {
                selectedtower.GetComponent<tower>().cancel_preview_next_tower();
            }
            close_panel();
        } 
        public void confirm_levelup()
        {
            Player_status.money-=selectedtower.GetComponent<tower>().levelup_cost;
            cancel_preview_next_tower();
            selectedtower.GetComponent<tower>().levelup();
            selectedtower=null;
            
        }
        public void close_panel()
        {
            subpanel_1.SetActive(false);
            subpanel_2.SetActive(false);
            subpanel_3.SetActive(false);
            subpanel_4.SetActive(false);
            //selectpanel.SetActive(false);
        } 
        public void soldier_preview_tower()
        {
            selectedtower.GetComponent<build_point>().choose_next_tower(1);
            preview=true;
            selectedtower.GetComponent<build_point>().preview_next_tower();
            selectedtower.GetComponent<build_point>().soldier_levelup_cost();
            close_panel();
            subpanel_2.SetActive(true);
        }
        public void archer_preview_tower()
        {
            selectedtower.GetComponent<build_point>().choose_next_tower(2);
            preview=true;
            selectedtower.GetComponent<build_point>().preview_next_tower();
            selectedtower.GetComponent<build_point>().archer_levelup_cost();
            close_panel();
            subpanel_2.SetActive(true);
        } 
        public void mage_preview_tower()
        {
            selectedtower.GetComponent<build_point>().choose_next_tower(3);
            preview=true;
            selectedtower.GetComponent<build_point>().preview_next_tower();
            selectedtower.GetComponent<build_point>().mage_levelup_cost();
            close_panel();
            subpanel_2.SetActive(true);
        }
        public void canon_preview_tower()
        {
            selectedtower.GetComponent<build_point>().choose_next_tower(4);
            preview=true;
            selectedtower.GetComponent<build_point>().preview_next_tower();
            selectedtower.GetComponent<build_point>().canon_levelup_cost();
            close_panel();
            subpanel_2.SetActive(true);
        } 
        public void pause_game()
        {
            wave_spawner.tim=0f;
            Show_pause_panel();
        } 
        public void Show_pause_panel()
        {
            pause_panel.SetActive(true);
        }
        public void continue_game()
        {
            if(speedup)
            {
                wave_spawner.tim=2f;
            }else
            {
                wave_spawner.tim=1f;
            }
            Close_pause_panel();
        } 
        public void Close_pause_panel()
        {
            pause_panel.SetActive(false);
        } 
        public void speedup_game()
        {
            if(wave_spawner.tim==1f)
            {
                wave_spawner.tim=2f;
            }
            else
            {
                wave_spawner.tim=1f;
            }   
        } 
        public void sell_tower()
        {   
            Debug.Log("sell");
            Player_status.money+=selectedtower.GetComponent<tower>().value;
            GameObject newbuildpoint=Instantiate(BP,selectedtower.transform.position,selectedtower.transform.rotation);
            close_panel();
            Destroy(selectedtower);
        } 
        public void movedestination()
        {
            movesoldierdestination=true;
            selectedtower.GetComponent<tower>().showrange();
            close_panel();
        } 
        public void click_button()
        {
            click.Play();
        }   
    }
}
