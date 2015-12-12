using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
    public GameObject wall;
    public GameObject powerup;

    float timeElapsed = 0;
    float spawnCycle = 0.5f;
    bool spawnPowerup = true;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > spawnCycle)
        {
            GameObject temp;
            if (spawnPowerup)
            {
                temp = (GameObject)Instantiate(powerup);
                Vector3 pos = temp.transform.position;
                temp.transform.position = new Vector3(Random.Range(-1, 2), 0.85f, 40);
            }
            else
            {
                temp = (GameObject)Instantiate(wall);
                Vector3 pos = temp.transform.position;
                temp.transform.position = new Vector3(Random.Range(-1, 2), 0.85f, 40);
            }

            timeElapsed -= spawnCycle;
            spawnPowerup = !spawnPowerup;
        }
    }
}
