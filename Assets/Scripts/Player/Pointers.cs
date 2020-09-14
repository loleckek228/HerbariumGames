using System;
using UnityEngine;
using UnityEngine.UI;

public class Pointers : MonoBehaviour
{
    [SerializeField] LevelGenerator _levelGenerator;
    [SerializeField] private Button _leftPointer;
    [SerializeField] private Button _rightPointer;

    private PlayerMovement _playerMovement;
    private GameStateUi _gameStateUi;

    private void Start()
    {
        SetActiveForButtons(true);

        _playerMovement = _levelGenerator.GetPlayer().GetPlayerMovement();
        _gameStateUi = _levelGenerator.GetPlayer().GetLosing();

        _playerMovement.Moving += OnMoving;
        _gameStateUi.Losing += OnChangeStateGame;
        _gameStateUi.Winnings += OnChangeStateGame;
    }

    private void OnDisable()
    {
        _playerMovement.Moving -= OnMoving;
        _gameStateUi.Losing -= OnChangeStateGame;
        _gameStateUi.Winnings -= OnChangeStateGame;
    }

    public void OnLeftButtonClickBehavior()
    {
        _playerMovement.OnLeftPointerClick();
    }

    public void OnRightButtonClickBehavior()
    {
        _playerMovement.OnRightPointerClick();
    }

    private void OnMoving(Boolean isMoving)
    {
        if (isMoving)
        {
            SetActiveForButtons(false);
        }
        else
        {
            SetActiveForButtons(true);
        }
    }

    private void OnChangeStateGame()
    {
        SetActiveForButtons(false);
    }

    private void SetActiveForButtons(bool isActive)
    {
        _leftPointer.gameObject.SetActive(isActive);
        _rightPointer.gameObject.SetActive(isActive);
    }
}