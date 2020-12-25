using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class wave_spawner : MonoBehaviour
{
    public Transform enemyPrefabs;
    public Transform spawnpoint;
    public GameObject portal;
    public float timeBetweenWaves = 10f;
    public float countdown = 2f;
    //private int waveIndex=0;
    public static float tim=1;
    public static bool finish_spawn=true;
    [SerializeField] TextMeshProUGUI wave_info_text;
    public wave[] waves;
    public int maximum_wave;
    public int cur_wave;
    public static int active_enemy_amount=0;
    public static bool win=false;
    public bool start=true;
    // Start is called before the first frame update
    void Start()
    {
        tim=1f;
        win=false;
        finish_spawn=true;
        //Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = tim;
        if(countdown<=0f&&finish_spawn&&cur_wave<maximum_wave&&start)
        {   
            //portal.SetActive(true);

            StartCoroutine(Spawnwave(cur_wave));
            //countdown=timeBetweenWaves;

        }
        if(finish_spawn)
        {
            countdown-=Time.deltaTime;
        }
        if(cur_wave==maximum_wave&&finish_spawn)
        {
            GameObject[]enemies= GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies)
            {
                if(enemy!=null)
                {
                    return;
                }
            }
            win=true;
        }
        wave_info_text.text=cur_wave+"/"+maximum_wave;
        //will implement visualization of count down in future

        //leave it here now
    }
    IEnumerator Spawnwave(int waveIndex)
    { 
        finish_spawn=false;
        portal.SetActive(true);
        countdown=timeBetweenWaves;
        cur_wave++;
        yield return new WaitForSeconds(1f);
        wave enemywave = waves[waveIndex];
 
        for (int a = 0; a < enemywave.waveCount; a++)
        {
            // yield return new WaitForSeconds(1f);

            for (int i = 0; i < enemywave.enemyWave[a].enemyCount; i++)
            {
                SpawnEnemy(enemywave.enemyWave[a].enemy);
                yield return new WaitForSeconds(1.5f);
            }
        }
 
        // waveIndex++;
        // finish_spawn=false;
        // portal.SetActive(true);
        // yield return new WaitForSeconds(1f);
        // for(int i=0;i<waveIndex+1;i++)
        // {
        //     //portal.SetActive(true);
            
        //     yield return new WaitForSeconds(1f);
        //     SpawnEnemy();

        // }
        yield return new WaitForSeconds(1f);  
        //waveIndex++;
        
        finish_spawn=true;
        //countdown=timeBetweenWaves;
        portal.SetActive(false);
        //Debug.Log("wave coming");
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy,spawnpoint.position,spawnpoint.rotation);
        active_enemy_amount++;
    }

}
