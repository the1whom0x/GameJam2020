﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private static MainMenuManager _instance;

    private enum Panel { TitleScreen, PlayerSelection }
    private Panel _currentPanel = Panel.TitleScreen;

    public bool TryAssigning = false;


    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
        }
    }


    private void Update()
    {

        if (_currentPanel == Panel.TitleScreen)
        {

            if (Input.GetKeyDown(KeyCode.Joystick1Button7))
            {
                _currentPanel = Panel.PlayerSelection;
                UIManager.instance.SwitchToPlayerSelectionScreen();
                StartCoroutine(TryAssigningAfterDelay(1));
            }
            
        }
        else if (_currentPanel == Panel.PlayerSelection)
        {
            if (JoystickManager.GetInstance().GetJoystick(1).Assigned &&
                JoystickManager.GetInstance().GetJoystick(2).Assigned)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Joystick2Button7))
                {
                    SceneManager.LoadScene(/*"Level 1"*/"Level 1 - 2D");
                }  
            }
        }

    }

    IEnumerator TryAssigningAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        TryAssigning = true;
    }

    public static MainMenuManager GetInstance() { return _instance; }

    public void SpawnPlayers(params GameObject[] playersToSpawn)
    {
        foreach (GameObject go in playersToSpawn)
        {
            SpawnRandom(go, transform);
        }
    }

    void SpawnRandom(GameObject toSpawn)
    {

        Vector3 randomPos = new Vector3(
            Random.Range(-5, 5), //x
            0.0f, //y
            Random.Range(-5, 5)); //z

    }

    void SpawnRandom(GameObject toSpawn, Transform parentToSet)
    {

        Vector3 randomPos = new Vector3(
            Random.Range(-5, 5), //x
            0.0f, //y
            Random.Range(-5, 5)); //z

        toSpawn.transform.SetParent(parentToSet);
        toSpawn.transform.position = randomPos;
        toSpawn.GetComponent<PlayerController>().enabled = true;
       
    }

}
