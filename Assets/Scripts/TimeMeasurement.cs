using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeMeasurement : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI finishDisplay;
    [SerializeField]
    private TextMeshProUGUI timerDisplay;

    private float startTime;
    private float timeElapsed;
    private float currentTime;
    private float displayedTime;
    private bool isCounting = false;

    private void Start()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
    }

    private void Update()
    {
        if (isCounting)
        {
            currentTime += Time.deltaTime;
            if (currentTime - displayedTime >= 0.01f)
            {
                displayedTime = currentTime;
                timerDisplay.text = $"{System.Math.Round(displayedTime, 2)} s";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StartFlag")
        {
            startTime = Time.time;
            currentTime = 0;
            displayedTime = 0;
            isCounting = true;
        }

        if (other.tag == "FinishFlag")
        {
            if(isCounting)
            {
                timeElapsed = Time.time - startTime;
                finishDisplay.text = $"time: \n{timeElapsed} s";
                finishDisplay.gameObject.SetActive(true);
                isCounting = false;
            }
        }
    }
}
