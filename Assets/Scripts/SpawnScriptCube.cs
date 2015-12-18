using UnityEngine;
using System.Collections;

public class SpawnScriptCube : MonoBehaviour
{
    public GameObject Wall;
    public GameObject powerup;
    public GameObject MovingWall;
    public GameObject Wall2;

    float multiplier = 0;
    float totalTimeElapsed=0;
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

    Vector3 Bot = new Vector3(3.57f, 3, 80);
    Vector3 Right = new Vector3(5.54f, 4.93f, 80);
    Vector3 Left = new Vector3(1.62f, 4.93f, 80);
    Vector3 Top = new Vector3(3.57f, 6.5f, 80);

    void Update()
    {
        GameObject temp;
        multiplier = 1 + totalTimeElapsed / 30;
        totalTimeElapsed += Time.deltaTime;
        timeElapsed += Time.deltaTime;
        powerElapsed += Time.deltaTime;
        cityRightElapsed += Time.deltaTime;
        cityLeftElapsed += Time.deltaTime;
        towerRightElapsed += Time.deltaTime;
        towerLeftElapsed += Time.deltaTime;

        if (timeElapsed > powerCycle)
        {
            spawnPowerup = !spawnPowerup;
            powerpos = Random.Range(0,4);
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

            temp = (GameObject)Instantiate(Wall2);
            int position = (powerpos +Random.Range(0, 6))%4;
            if (position == 0) temp.transform.position = Bot;
            else if (position == 1)
            {
                temp.transform.position = Right;
                temp.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (position == 2)
            {
                temp.transform.position = Left;
                temp.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else temp.transform.position = Top;
            cityRightElapsed = 0;
            randtime1 = Random.Range(1, 20) / (3*multiplier);
        }
        if (cityLeftElapsed > randtime2)
        {

            temp = (GameObject)Instantiate(Wall2);
            int position = (powerpos + Random.Range(0, 6)) % 4;
            if (position == 0) temp.transform.position = Bot;
            else if (position == 1)
            {
                temp.transform.position = Right;
                temp.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (position == 2)
            {
                temp.transform.position = Left;
                temp.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else temp.transform.position = Top;
            cityLeftElapsed = 0;
            randtime2 = Random.Range(1, 20) / (3 * multiplier);
        }
        if (towerRightElapsed > randtime3)
        {

           temp = (GameObject)Instantiate(MovingWall);

            temp.transform.position = new Vector3(3.36f, 3, Random.Range(40, 65));
           
           towerRightElapsed = 0;
           randtime3 = Random.Range(1, 12) /(2 * multiplier);
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