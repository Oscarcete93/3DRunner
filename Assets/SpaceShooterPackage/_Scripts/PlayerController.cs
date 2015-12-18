﻿using UnityEngine;
using System.Collections;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour {
	//public float jumpForce;
    private AudioSource audioSource;
    private Rigidbody rb;
    public float speed;
    public float tilt;
    //public Boundary boundary;
	public float xMin;
	public float xMax;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

	//private float high;
    private float nextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audioSource.Play();
        }
    }



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
		/*float jump = 1.0f;
		if (Input.GetButton ("Jump")) {
			jump = jumpForce;
		}*/
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rb.velocity = movement * speed;
        
        rb.position = new Vector3 (Mathf.Clamp(rb.position.x, xMin, xMax),0.0f,0.0f);

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

    }

}
