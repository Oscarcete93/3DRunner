﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    //public GUIText scoreText;
    //public GUIText restartText;
    //public GUIText gameOverText;

    private bool gameOver;
    //private bool restart;
    private int score;

	public AudioSource countdownSound; //reference to the audio source
	private bool isCountDown = false; //countdown flag
	public int countMax;  //max countdown number
	private int countDown;  //current countdown number
	public Text TextCountDown;//GUIText reference
	// Use this for initialization

	public GUISkin skin;
	public float timeRemaining;
	private float timeExtension;
	//private float timeDeduction;
	public int lifes;
	private float totalTimeElapsed;
	private bool completed;

	public GameObject destination;
	private float maxZ;

    void Start()
    {
        gameOver = false;
        //restart = false;
		Time.timeScale = 1;
        //restartText.text = "";
        //gameOverText.text = "";
		//timeRemaining = 120;
		timeExtension = 3f;
		//timeDeduction = 2f;
		//lifes = 1;
		totalTimeElapsed = 0.0f;
		completed = false;
        score = 0;
        //UpdateScore();
		Rigidbody rb = destination.GetComponent<Rigidbody>();
		rb.velocity = new Vector3 (0.0f, 0.0f, (-60/timeRemaining));
		StartCoroutine(CountdownFunction());
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
		if (gameOver)return;

		totalTimeElapsed += Time.deltaTime;
		if (timeRemaining > 0) timeRemaining -= Time.deltaTime;
		else completed = true;
		if (lifes <1)
		{
			gameOver = true;
		}
    }

	void FixedUpdate() {
		//destination.transform.position = new Vector3 (0.0f, 0.0f, -40f);
	
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver || completed)
            {
				Rigidbody rb = destination.GetComponent<Rigidbody>();
				rb.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
                //restartText.text = "Press 'R' for Restart";
                //restart = true;
                break;
            }
        }
    }

	IEnumerator CountdownFunction()
	{
		//start the countdown
		countdownSound.PlayDelayed(.4f);
		for (countDown = countMax; countDown > -1; countDown--)
		{
			if (countDown != 0)
			{
                
				//display the number to the screen via the GUIText
				TextCountDown.text = countDown.ToString();
				//add a one second delay
				yield return new WaitForSeconds(1);
			}
			else
			{
				TextCountDown.text = "GO!";
				yield return new WaitForSeconds(1);
				//stop the sound
				countdownSound.Stop();
                isCountDown = true;  //set the flag to true
			}
		}
		//character.GetComponent<Animation>().enabled = true;
		//disable the GUIText once the countdown is done with
		TextCountDown.enabled = false;
	}



    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        //UpdateScore();
    }
	/*
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }*/

    public void GameOver()
    {
        //gameOverText.text = "Game Over!";
        gameOver = true;
    }

	public void getAttacked(int damage) {
		lifes -= damage;
	}

	public bool isAlive() {
		return lifes > 0;
	}


	void OnGUI()
	{
		GUI.skin = skin; //use the skin in game over menu
		//check if game is not over, if so, display the score and the time left

		if (completed)
		{
			Time.timeScale = 0; //set the timescale to zero so as to stop the game world
			//display the final score
			GUI.Box(new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2), "LEVEL COMPLETED!\nYOUR SCORE: " + (int)score+"\n"+
			"Your ship has entered into fifth dimension\n" + "now try to escape!");

			//restart the game on click
			if (GUI.Button(new Rect(Screen.width / 4 + 10, Screen.height / 4 + Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "NEXT"))
			{
				Application.LoadLevel("Level 2");
			}

			//restart the game on click
			if (GUI.Button(new Rect(Screen.width / 4 + 10, Screen.height / 4 + 2*Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "RESTART"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}

			//load the main menu, which as of now has not been created
			if (GUI.Button(new Rect(Screen.width / 4 + 10, Screen.height / 4 + 3* Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "MAIN MENU"))
			{
				Application.LoadLevel("MainMenu");
			}

			//exit the game
			if (GUI.Button(new Rect(Screen.width / 4 + 10, Screen.height / 4 + 4 * Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "EXIT GAME"))
			{
				Application.Quit();
			}

		}
		else if (!gameOver)
		{
			GUI.Label(new Rect(10, 10, Screen.width / 5, Screen.height / 6), "TIME LEFT: " + ((int)timeRemaining).ToString());
			GUI.Label(new Rect(Screen.width - (Screen.width / 6), 10, Screen.width / 6, Screen.height / 6), "SCORE: " + ((int)score).ToString());
			GUI.Label(new Rect(10, Screen.height - Screen.height / 8, Screen.width / 5, Screen.height), "LIFES: " + lifes.ToString());

		}
		else {
			Time.timeScale = 0; //set the timescale to zero so as to stop the game world
			//display the final score
			GUI.Box(new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2), "GAME OVER\nYOUR SCORE: " + (int)score);

			//restart the game on click
			if (GUI.Button(new Rect(Screen.width / 4 + 10, Screen.height / 4 + Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "RESTART"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}

			//load the main menu, which as of now has not been created
			if (GUI.Button(new Rect(Screen.width / 4 + 10, Screen.height / 4 + 2 * Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "MAIN MENU"))
			{
				Application.LoadLevel("MainMenu");
			}

			//exit the game
			if (GUI.Button(new Rect(Screen.width / 4 + 10, Screen.height / 4 + 3 * Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "EXIT GAME"))
			{
				Application.Quit();
			}
		}
	}






}
