using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    public GameObject[] canvas; //UI - First element

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            canvas[0].SetActive(false);
            canvas[1].SetActive(true);
        } else if (Input.GetKeyUp(KeyCode.T))
        {
            canvas[0].SetActive(true);
            canvas[1].SetActive(false);
        }
    }
}
