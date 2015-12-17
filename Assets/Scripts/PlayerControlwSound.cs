using UnityEngine;
using System.Collections;


public class PlayerControlwSound : MonoBehaviour
{
    public CountDownScript3 count;  //CountdownScript instance
    public PauseMenuScript pause;  //PauseMenuScript instance
                                   //audio source reference variables
    public AudioSource powerupCollectSound;
    public AudioSource WallCollideSound;
    public AudioSource LevelComplete;
    public AudioSource GameOver;
    CharacterController controller;
    float timer = 0;
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
        timer -= Time.deltaTime;
        if (control.isGameOver)
        {
            gameObject.GetComponent<AudioSource>().enabled = false;
            GameOver.Play();
        }
        if (control.completed)
        {
            gameObject.GetComponent<AudioSource>().enabled = false;
            LevelComplete.Play();
        }

    }

    //check if the character collects the powerups or the snags
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "powerup(Clone)" && timer<0)
        {
            control.PowerupCollected();
            powerupCollectSound.Play();  //play powerup collected sound
            timer = 0.1f;
        }
        else if (other.gameObject.name == "wall(Clone)" && timer < 0)
        {

            control.WallCollision();
            WallCollideSound.Play();  //play powerup collected sound
            timer = 0.1f;
        }
        else if (other.gameObject.name == "wall2(Clone)" && timer < 0)
        {

            control.WallCollision();
            WallCollideSound.Play();  //play powerup collected sound
            timer = 0.1f;
        }
        else if (other.gameObject.name == "MovingWall(Clone)" && timer < 0)
        {

            control.WallCollision();
            WallCollideSound.Play();  //play powerup collected sound
            timer = 0.1f;
        }
        Destroy(other.gameObject);            //destroy the snag or powerup if colllected by the player

    }
}