using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject player;

    public PlayerMovement playerMovement;

    // Enum representing different game states
    public enum GameState
    {
        MainMenu_State,
        Gameplay_State,
        Paused_State,
        Options_State
    }

    public GameState currentState { get; private set; }

    [SerializeField] private string currentStateDebug;
    [SerializeField] private string lastStateDebug;

    public GameState LastState;

    private void Start()
    {
        ChangeState(GameState.MainMenu_State);

        playerMovement = player.GetComponent<PlayerMovement>();
    }

    public void ChangeState(GameState newState)
    {
        lastStateDebug = currentState.ToString();
        LastState = currentState;

        currentState = newState;

        HandleStateChange(newState);

        currentStateDebug = currentState.ToString();
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (currentState == GameState.Gameplay_State || currentState == GameState.Paused_State))
        {
            if (currentState == GameState.Paused_State)
            {
                ChangeState(GameState.Gameplay_State);
            }
            else
            {
                ChangeState(GameState.Paused_State);
            }
        }
    }

    private void HandleStateChange(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu_State:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                playerMovement.CanMove = false;

                gameManager.UIManager.EnableMainMenu();

                player.transform.position = new Vector3(-2.35f, 0, 0);

                Time.timeScale = 0;
                break;

            case GameState.Gameplay_State:
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                playerMovement.CanMove = true;

                gameManager.UIManager.EnableGameplay();

                Time.timeScale = 1;
                break;

            case GameState.Paused_State:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                playerMovement.CanMove = false;

                gameManager.UIManager.EnablePause();

                Time.timeScale = 0;
                break;

            case GameState.Options_State:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                gameManager.UIManager.EnableOptions();

                Time.timeScale = 0;
                break;
        }
    }
}