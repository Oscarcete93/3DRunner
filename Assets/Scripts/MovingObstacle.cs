using UnityEngine;
using System.Collections;

public class MovingObstacle : MonoBehaviour
{
    public float objectSpeed = -0.5f;
    public float SlowSpeed = 0.05f;

    void Update()
    {
        transform.Translate(0, 0, objectSpeed * Time.timeScale);
        transform.Translate(0, SlowSpeed * Time.timeScale, objectSpeed * Time.timeScale);
    }
}