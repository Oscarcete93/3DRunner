using UnityEngine;
using System.Collections;

public class SpawnScript2 : MonoBehaviour
{
    public GameObject wall;
    public GameObject powerup;
    public GameObject rampa;

    float timeElapsed = 0;
    float powerElapsed = 0;
    float spawnCycle = 0.2f;
    float powerCycle = 2;
    bool spawnPowerup = true;
    float powerpos;
    void Update()
    {
        GameObject temp;
        timeElapsed += Time.deltaTime;
        powerElapsed += Time.deltaTime;
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
         

           
           
        }
    }
