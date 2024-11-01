using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    private void OnEnable()
    {
        Health.OnPlayerDeath += HandlePlayerDeath;
    }
    private void OnDisable()
    {
        Health.OnPlayerDeath -= HandlePlayerDeath;
    }

    private void HandlePlayerDeath()
    {
        LoadGameOver();
    }

    public void LoadGame()
    {
        ScoreManager.instance.ResetScore();
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitSceneWithLoadTime(1.5f, "Game Over"));
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game..");
        Application.Quit();
    }
    private IEnumerator WaitSceneWithLoadTime(float delay, string sceneName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
