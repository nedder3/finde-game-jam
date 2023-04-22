using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseControl : MonoBehaviour
{
    bool paused = false;
    public UnityEvent GamePaused;
    public UnityEvent GameResumed;

    void Start () {
        Debug.Log("pause control start");
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("PauseControl escape");

            paused = !paused;

            if (paused) 
            {
                Time.timeScale = 0;
                GamePaused.Invoke();
            }

            else 
            {
                Time.timeScale = 1;
                GameResumed.Invoke();
            }
           
        }
    }
}
