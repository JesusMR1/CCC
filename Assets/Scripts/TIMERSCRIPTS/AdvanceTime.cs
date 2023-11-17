using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdvanceTime : MonoBehaviour
{
    [SerializeField] private int startingTime;
    [SerializeField] private float timeUntilHourChange;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private int timeLimit;

    [NonSerialized] public int timeHours;

    private bool isTimeLimitReached = false;

    public AnimDialogo animDialogo;



    private void Start()
    {
        timeHours = startingTime;

        StartCoroutine(AdvanceHourOverTime());
    }

    private void Update()
    {
        if (!isTimeLimitReached)
        {
            timeText.text = timeHours + ":00 PM";
        }
    }

    private IEnumerator AdvanceHourOverTime()
    {
        yield return new WaitForSeconds(timeUntilHourChange);

        if (timeHours == 12)
        {
            timeHours = 1;
        }
        else
        {
            timeHours++;
        }

        if (timeHours < timeLimit)
        {
            StartCoroutine(AdvanceHourOverTime());
        }
        else
        {
            // The time limit has been reached. Wait for 3 seconds and then hide the text.
            yield return new WaitForSeconds(3f);
            timeText.gameObject.SetActive(false);
            isTimeLimitReached = true;


            animDialogo.Mensaje();
        }
    }
}