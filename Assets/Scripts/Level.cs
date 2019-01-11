using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    public void LoadGame()
    {
        SceneManager.LoadScene("Splash");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        FindObjectOfType<GameData>().ResetScore();
        SceneManager.LoadScene("Splash");
    }
}
