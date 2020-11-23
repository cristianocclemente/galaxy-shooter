﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject _pauseMenuPanel;

    private UIManager _uiManager;
    private SpawnManager _spawnManager;
    private Animator _pauseAnimator;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _pauseAnimator = GameObject.Find("Pause_Menu_Panel").GetComponent<Animator>();
        _pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime; //allows pause menu animation despite the time being frozen
    }

    private void Update()
    {
        if (gameOver == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(player, new Vector3(0, -4.2f, 0), Quaternion.identity);
                gameOver = false;
                _uiManager.HideTitleScreen();
                _spawnManager.StartSpawnRoutines();
            }
        }
    }

    public void PauseGame()
    {
        _pauseMenuPanel.SetActive(true);
        _pauseAnimator.SetBool("isPaused", true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        _pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
