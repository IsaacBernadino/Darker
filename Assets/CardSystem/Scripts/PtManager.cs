using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PtManager : MonoBehaviour
{

    public int points = 500;

    public Text pts;

    public float time;
    float currentTime;

    void Start()
    {
        currentTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        if(points <= 0)
        {
            points = 0;
        }

        pts.text = points.ToString();

        if(currentTime <= 0)
        {
            points++;
            currentTime = time;
        } else
        {
            currentTime -= Time.deltaTime;
        }
    }

    public void UsedPoints (int value)
    {
        points -= value;
    }
}
