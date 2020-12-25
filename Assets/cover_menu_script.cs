using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cover_menu_script : MonoBehaviour
{
    public GameObject mainpanel;
    public GameObject Loadpanel;
    public GameObject OptionPanel;
    public GameObject save1;
    public GameObject save2;
    public GameObject save3;
    public GameObject newgame1;
    public GameObject newgame2;
    public GameObject newgame3;
    public Player player;
    public AudioSource click;
    public Animator transition;
    public float transitionTime=1f;
    public void LoadScene()
    {
        StartCoroutine(Loadscenewithtransition());
    }
    IEnumerator Loadscenewithtransition()
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void defaultplayerdata()
    {
        Player.levelachieved=0;
        Player.stars=0;
        Player.crystals=0;
        Player.skill_1_level=0;
        Player.skill_2_level=0;
        Player.skill_3_level=0;
        Player.skill_4_level=0;
        Player.skill_5_level=0;
        Player.skill_6_level=0;
        Player.item_1_amount=0;
        Player.item_2_amount=0;
        Player.item_3_amount=0;
        Player.item_4_amount=0;
        Player.hero1=false;
        Player.hero2=false;
        Player.hero3=false;
        Player.save_NUM=0;
    }
    public void createsave1()
    {
        defaultplayerdata();
        Player.save_NUM=1;
        Debug.Log(Player.save_NUM);
        SaveSystem.SavePlayer(Player.save_NUM);
        newgame1.SetActive(false);
        save1.SetActive(true);

    }
    public void DeleteSave1()
    {
        SaveSystem.DeletePlayer(1);
        newgame1.SetActive(true);
        save1.SetActive(false);
    }
    public void createsave2()
    {
        defaultplayerdata();
        Player.save_NUM=2;
        Debug.Log(Player.save_NUM);
        SaveSystem.SavePlayer(2);
        newgame2.SetActive(false);
        save2.SetActive(true);

    }
    public void DeleteSave2()
    {
        SaveSystem.DeletePlayer(2);
        newgame2.SetActive(true);
        save2.SetActive(false);
    }
    public void createsave3()
    {
        defaultplayerdata();
        Player.save_NUM=3;
        SaveSystem.SavePlayer(3);
        newgame3.SetActive(false);
        save3.SetActive(true);

    }
    public void DeleteSave3()
    {
        SaveSystem.DeletePlayer(3);
        newgame3.SetActive(true);
        save3.SetActive(false);
    }
    public void Loadsave1()
    {
        
        player.LoadPlayer(1);
        Debug.Log(Player.save_NUM);
        LoadScene();
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Loadsave2()
    {
        Debug.Log(Player.save_NUM);
        player.LoadPlayer(2);
        LoadScene();
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Loadsave3()
    {
        Debug.Log(Player.save_NUM);
        player.LoadPlayer(3);
        LoadScene();
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    
    public void QuitGame(){
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void StartGame()
    {
        Loadpanel.SetActive(true);
        mainpanel.SetActive(false);
    }
    public void showoptionmenu()
    {
        OptionPanel.SetActive(true);
        mainpanel.SetActive(false);
    }
    public void returnmainmenu()
    {
        OptionPanel.SetActive(false);
        Loadpanel.SetActive(false);
        mainpanel.SetActive(true);
    }
    public void click_button()
    {
        click.Play();
    } 
}
