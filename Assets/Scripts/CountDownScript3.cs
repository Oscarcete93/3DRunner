using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDownScript3 : MonoBehaviour
{

    public GameObject character;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;


    public int countMax;  //max countdown number
    private int countDown;  //current countdown number
    public Text TextCountDown;//GUIText reference
                              // Use this for initialization
    void Start()
    {
        MonoBehaviour[] scriptComponentsGameControl = gameObject.GetComponents<MonoBehaviour>();   //get all the script components attached
                                                                                                   //loop through all the scripts and disable them
        foreach (MonoBehaviour script in scriptComponentsGameControl)
        {
            script.enabled = false;
        }

        //disable all the scripts attached to the walls, ground. Also disable the animation of character
        wall1.GetComponent<GroundControl>().enabled = false;
        wall2.GetComponent<GroundControl>().enabled = false;
        wall3.GetComponent<GroundControl>().enabled = false;
        wall4.GetComponent<GroundControl>().enabled = false;

        //character.GetComponent<Animation>().enabled = false;

        //Call the CountdownFunction
        StartCoroutine(CountdownFunction());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CountdownFunction()
    {
        //start the countdown
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
            }
        }
        //enable all the scripts and animation once the count is down
        MonoBehaviour[] scriptComponentsGameControl = gameObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scriptComponentsGameControl)
        {
            script.enabled = true;
        }

        wall1.GetComponent<GroundControl>().enabled = true;
        wall2.GetComponent<GroundControl>().enabled = true;
        wall3.GetComponent<GroundControl>().enabled = true;
        wall4.GetComponent<GroundControl>().enabled = true;

        //character.GetComponent<Animation>().enabled = true;
        //disable the GUIText once the countdown is done with
        TextCountDown.enabled = false;
    }
}