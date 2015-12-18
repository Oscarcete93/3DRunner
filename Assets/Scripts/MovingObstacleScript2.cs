using UnityEngine;
using System.Collections;

public class MovingObstacleScript2 : MonoBehaviour
{
    public float SlowSpeed = 0.1f;
    public float time = 0;
    int d = 1;
    void Update()
    {
        time += Time.deltaTime;
        transform.Translate(SlowSpeed * Time.timeScale * d, 0, 0, Space.World);
        if (time > 1.4)
        {
            time = 0;
            d = -d;
        }

    }
}