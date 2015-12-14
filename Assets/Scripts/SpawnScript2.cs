using UnityEngine;
using System.Collections;

public class SpawnScript2 : MonoBehaviour
{
    public GameObject Building;
    public GameObject powerup;
    public GameObject tower;

    float timeElapsed = 0;
    float powerElapsed = 0;
    float cityRightElapsed = 0;
    float cityLeftElapsed = 0;
    float towerRightElapsed = 0;
    float towerLeftElapsed = 0;
    float spawnCycle = 0.2f;
    float powerCycle = 2;
    bool spawnPowerup = true;
    float powerpos;
    float randtime1 = 3;
    float randtime2 = 3;
    float randtime3 = 3;
    float randtime4 = 3;
    void Update()
    {
        GameObject temp;
        timeElapsed += Time.deltaTime;
        powerElapsed += Time.deltaTime;
        cityRightElapsed += Time.deltaTime;
        cityLeftElapsed += Time.deltaTime;
        towerRightElapsed += Time.deltaTime;
        towerLeftElapsed += Time.deltaTime;
  
        if (timeElapsed > powerCycle)
        {
            spawnPowerup = !spawnPowerup;
            powerpos = Random.Range(-10, 10);
            timeElapsed = 0;
        }
        if (spawnPowerup && powerElapsed > spawnCycle)
        {
            temp = (GameObject)Instantiate(powerup);
            powerpos += Random.Range(-1, 1);
            temp.transform.position = new Vector3(powerpos, 0.85f, 80);
            powerElapsed = 0;
        }   
         if(cityRightElapsed> randtime1)
        {
            
            temp = (GameObject)Instantiate(Building);
            int distance = Random.Range(4, 15);
            temp.transform.position = new Vector3(powerpos + distance, 0, 80);
            cityRightElapsed = 0;
            randtime1 = Random.Range(1, 12)/10;
        }
        if (cityLeftElapsed > randtime2)
        {

            temp = (GameObject)Instantiate(Building);
            int distance = Random.Range(4, 15);
            temp.transform.position = new Vector3(powerpos - distance, 0, 80);
            cityLeftElapsed = 0;
            randtime2 = Random.Range(1, 12) / 10;
        }
        if (towerRightElapsed > randtime3)
        {

            temp = (GameObject)Instantiate(tower);
            int distance = Random.Range(4, 15);
            temp.transform.position = new Vector3(powerpos + distance, 0, 80);
            towerRightElapsed = 0;
            randtime3 = Random.Range(1, 12) / 10;
        }
        if (towerLeftElapsed > randtime4)
        {

            temp = (GameObject)Instantiate(tower);
            int distance = Random.Range(4, 15);
            temp.transform.position = new Vector3(powerpos - distance, 0, 80);
            towerLeftElapsed = 0;
            randtime4 = Random.Range(1, 12) / 10;
        }


    }
    }
