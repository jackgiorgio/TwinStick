using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;
    private float initialFixedDelta;
    private bool isPause;

    // Use this for initialization
    void Start() {
        PlayerPrefsManager.UnLockLevel(2);
        initialFixedDelta = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update() {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P) && !isPause)
        {
            isPause = true;
            PauseGame();     
        }

        if (Input.GetKeyDown(KeyCode.P) && !isPause)
        {
            isPause = false;
            ResumeGame();
        }

    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = initialFixedDelta;
    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPause = pauseStatus;
    }
}
