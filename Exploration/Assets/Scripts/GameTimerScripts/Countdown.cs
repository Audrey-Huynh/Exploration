using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    public GameObject textDisplay;
    public int secondsLeft = 59;
    public bool takingAway = false;
    public int minutesLeft = 14;

    void Start()
    {

        if (secondsLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = minutesLeft + ":0" + secondsLeft;
        }
        else
        {
            textDisplay.GetComponent<Text>().text = minutesLeft + ":" + secondsLeft;
        }
    }

    void Update()
    {
        if (takingAway == false && secondsLeft >= 0 && minutesLeft >= 0)
        {
            StartCoroutine(TimerTake());
        }

        if(secondsLeft == 0 && minutesLeft ==0)
        {
            FindObjectOfType<GameManager>().Win();
        }

    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 0 && minutesLeft == 0)
        {
            minutesLeft = 0;
            secondsLeft = 0;
        }
        else if (secondsLeft < 0 && minutesLeft >= 0)
        {
            secondsLeft = 0;
            minutesLeft -= 1;
            secondsLeft = 59;
        }
        if (secondsLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = minutesLeft + ":0" + secondsLeft;
        }
        else
        {
            textDisplay.GetComponent<Text>().text = minutesLeft + ":" + secondsLeft;
        }
        takingAway = false;
    }

}
