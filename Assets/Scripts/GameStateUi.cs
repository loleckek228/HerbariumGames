using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateUi : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _buttonText;
    [SerializeField] private TMP_Text _gameStateText;

    public UnityAction Losing;
    public UnityAction Winnings;

    private void OnEnable()
    {
        Losing += OnLosing;
        Winnings += OnWinnings;
    }

    private void OnDisable()
    {
        Losing -= OnLosing;
        Winnings -= OnWinnings;
    }

    private void OnLosing()
    {
        _buttonText.text = "Try Again!";
        _gameStateText.text = "You Lose!";
        _button.gameObject.SetActive(true);
        _gameStateText.gameObject.SetActive(true);
    }

    private void OnWinnings()
    {
        _buttonText.text = "Menu";
        _gameStateText.text = "You Win!";

        _button.gameObject.SetActive(true);
        _gameStateText.gameObject.SetActive(true);
    }

    public void OnButtonCLick()
    {
        SceneManager.LoadScene("Menu");
    }
}