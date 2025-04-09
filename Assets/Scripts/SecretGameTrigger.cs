using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStateManager;

public class SecretGameTrigger : MonoBehaviour
{
    private GameStateManager stateManager;

    private void Start()
    {
        stateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
    }

    private void OnTriggerStay2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            stateManager.ChangeState(GameState.Ending_State);
        }
    }
}
