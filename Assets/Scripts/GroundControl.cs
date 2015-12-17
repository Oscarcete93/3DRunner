using UnityEngine;
using System.Collections;

public class GroundControl : MonoBehaviour {
    float speed = -4;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        //Offset the material texture at a constant rate
   
           float offset = Time.time * speed;
           GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -offset);

        
    }
}