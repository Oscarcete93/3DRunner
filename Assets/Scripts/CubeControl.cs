using UnityEngine;
using System.Collections;

public class CubeControl : MonoBehaviour
{
    //public Transform startMarker;
    //public Transform endMarker;
    //public float speed = 1.0F;
    //private float startTime;
    //private float journeyLength;
    //public Transform target;
    //public float smooth = 5.0F;
    //void Start()
    //{

    //}
    //void Update()
    //{
    //    if (Input.GetAxis("Horizontal") < 0)
    //    {
    //        target.position= new Vector3(1, 1, 1);
    //        startTime = Time.time;
    //        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    //    }
    //    float distCovered = (Time.time - startTime) * speed;
    //    float fracJourney = distCovered / journeyLength;
    //    transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
    //}
    //}

    Vector3 Bot;
    Vector3 Left;
    Vector3 Right;
    Vector3 Top;
    public float Speed;
    int state;
    int direction;

    void Start()
    {
        Bot = new Vector3(3.57f, 3, -56);
        Right = new Vector3(5.54f, 4.93f, -56);
        Left = new Vector3(1.62f, 4.93f, -56);
        Top = new Vector3(3.57f, 6.89f, -56);
        Speed = 0.2f;
        state = 0;

    }
    void Update()
    {
        Transform transform = GetComponent<Transform>();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (state == 0)
            {
                StartCoroutine(MoveObject(transform, transform.position, Left, Speed, Quaternion.Euler(0, 0, -90)));
                state = 1;
            }
            else if (state == 1)
            {
                StartCoroutine(MoveObject(transform, transform.position, Top, Speed, Quaternion.Euler(0, 0, -180)));
                state = 2;
            }
            else if(state == 2)
            {
                StartCoroutine(MoveObject(transform, transform.position, Right, Speed, Quaternion.Euler(0, 0, 90)));
                state = 3;
            }
            else
            {
                StartCoroutine(MoveObject(transform, transform.position, Bot, Speed, Quaternion.Euler(0, 0, 0)));
                state = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (state == 0)
            {
                StartCoroutine(MoveObject(transform, transform.position, Right, Speed, Quaternion.Euler(0, 0, 90)));
                state = 3;
            }
            else if (state == 1)
            {
                StartCoroutine(MoveObject(transform, transform.position, Bot, Speed, Quaternion.Euler(0, 0, 0)));
                state = 0;
            }
            else if (state == 2)
            {
                StartCoroutine(MoveObject(transform, transform.position, Left, Speed, Quaternion.Euler(0, 0, -90)));
                state = 1;
            }
            else
            {
                StartCoroutine(MoveObject(transform, transform.position, Top, Speed, Quaternion.Euler(0, 0, 180)));
                state = 2;
            }
        }
       
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time, Quaternion target)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            thisTransform.rotation = Quaternion.Slerp(transform.rotation, target, i);
            yield return null;
        }
    }
}