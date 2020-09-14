using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameStateUi gameStateUi;
    private PlayerMovement playerMovement;

    private void Start()
    {
        gameStateUi = FindObjectOfType<GameStateUi>();

        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        CheckingLose();
    }

    private void CheckingLose()
    {
        if (transform.position.y < -20)
        {
            gameObject.SetActive(false);
            gameStateUi.Losing?.Invoke();
        }
    }

    public GameStateUi GetLosing()
    {
        return gameStateUi;
    }

    public PlayerMovement GetPlayerMovement()
    {
        return playerMovement;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Chest chest))
        {
            gameStateUi.Winnings?.Invoke();
        }
    }
}