using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    private void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void Quit()
    {
        Application.Quit();
    }
}
