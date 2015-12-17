using UnityEngine;
using System.Collections;


public class PlayerControl : MonoBehaviour
{

    CharacterController controller;
    public GameControlScript control;
    bool isGrounded = false;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

    //start 
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //check if the character collects the powerups or the snags
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "powerup(Clone)")
        {
            control.PowerupCollected();
        }
        else if (other.gameObject.name == "wall(Clone)")
        {

            control.WallCollision();
        }
        else if (other.gameObject.name == "wall2(Clone)")
        {

            control.WallCollision();
        }
        else if (other.gameObject.name == "MovingWall(Clone)")
        {

            control.WallCollision();
        }
        Destroy(other.gameObject);            //destroy the snag or powerup if colllected by the player

    }
}