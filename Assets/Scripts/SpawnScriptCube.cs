using UnityEngine;
using System.Collections;

public class SpawnScriptCube : MonoBehaviour
{
    public GameObject Wall;
    public GameObject powerup;
    public GameObject MovingWall;

    float timeElapsed = 0;
    float powerElapsed = 0;
    float cityRightElapsed = 0;
    float cityLeftElapsed = 0;
    float towerRightElapsed = 0;
    float towerLeftElapsed = 0;
    float spawnCycle = 0.2f;
    float powerCycle = 2;
    bool spawnPowerup = true;
    int powerpos;
    float randtime1 = 1;
    float randtime2 = 1;
    float randtime3 = 1;
    float randtime4 = 1;

    Vector3 Bot = new Vector3(3.57f, 3.5f, 80);
    Vector3 Right = new Vector3(5, 4.93f, 80);
    Vector3 Left = new Vector3(2, 4.93f, 80);
    Vector3 Top = new Vector3(3.57f, 6.2f, 80);

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
            powerpos = Random.Range(0,3);
            timeElapsed = 0;
        }
        if (spawnPowerup && powerElapsed > spawnCycle)
        {
            temp = (GameObject)Instantiate(powerup);
            if (powerpos == 0)temp.transform.position = Bot;
            else if (powerpos == 1)
            {
                temp.transform.position = Right;
                temp.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (powerpos == 2)
            {
                temp.transform.position = Left;
                temp.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else temp.transform.position = Top;
            powerElapsed = 0;
        }
        if (cityRightElapsed > randtime1)
        {

            temp = (GameObject)Instantiate(Wall);
            int position = (powerpos +Random.Range(0, 2))%4;
            if (powerpos == 0) temp.transform.position = Bot;
            else if (powerpos == 1) temp.transform.position = Right;
            else if (powerpos == 2) temp.transform.position = Left;
            else temp.transform.position = Top;
            cityRightElapsed = 0;
            randtime1 = Random.Range(1, 12) / 7;
        }
        if (cityLeftElapsed > randtime2)
        {

            temp = (GameObject)Instantiate(Wall);
            int position = (powerpos + Random.Range(0, 2)) % 4;
            if (powerpos == 0) temp.transform.position = Bot;
            else if (powerpos == 1) temp.transform.position = Right;
            else if (powerpos == 2) temp.transform.position = Left;
            else temp.transform.position = Top;
            cityLeftElapsed = 0;
            randtime2 = Random.Range(1, 12) / 7;
        }
        if (towerRightElapsed > randtime3)
        {

           temp = (GameObject)Instantiate(MovingWall);
           
           temp.transform.position = new Vector3(3.36f, 1.88f, 80);
           
           towerRightElapsed = 0;
           randtime3 = Random.Range(1, 12) / 7;
           }
        //if (towerLeftElapsed > randtime4)
        //{

        //    temp = (GameObject)Instantiate(tower);
        //    int distance = Random.Range(4, 15);
        //    temp.transform.position = new Vector3(powerpos - distance, 0, 80);
        //    temp.transform.localScale = new Vector3(Random.Range(2, 6), Random.Range(2, 6), Random.Range(2, 6));
        //    towerLeftElapsed = 0;
        //    randtime4 = Random.Range(1, 12) / 7;
        //}


    }
}