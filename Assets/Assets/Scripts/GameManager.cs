﻿using UnityEngine;
using System.Collections;
public enum GameState
{
    menu,
    inGame,
    gameOver
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState currentGameState = GameState.menu;
    public Canvas menuCanvas;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentGameState = GameState.menu;
    }
    //called to start the game
    public void StartGame()
    {
        PlayerController.instance.StartGame();
        SetGameState(GameState.inGame);
    }
    //called when player die
    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }
    //called when player decide to go back to the menu
    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }
    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //setup Unity scene for menu state
            menuCanvas.enabled = true;
        }
        else if (newGameState == GameState.inGame)
        {
            //setup Unity scene for inGame state
            menuCanvas.enabled = false;
        }
        else if (newGameState == GameState.gameOver)
        {
            //setup Unity scene for gameOver state
            menuCanvas.enabled = false;
        }
        currentGameState = newGameState;
    }
    void Update()
    {
        if (Input.GetButtonDown("s"))
        {
            StartGame();
        }
    }
}