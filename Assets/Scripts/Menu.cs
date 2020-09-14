using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void Сustomization()
    {
        SceneManager.LoadScene("Сustomization");
    }

    public void Exit()
    {
        Application.Quit();
    }
}