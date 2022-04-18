using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public static Action OnGameOver;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void Win()
    {
        Result result = new Result
        {
            Time = BallMovement.Instance.Seconds,
            Message = "Вы победили!",
            IsWon = true
        };
        OnGameOver?.Invoke();
        SaveLoadProgress.SaveData(result);
    }

    public void Lose()
    {
        Result result = new Result
        {
            Time = BallMovement.Instance.Seconds,
            Message = "Вы проиграли!",
            IsWon = false
        };
        OnGameOver?.Invoke();
        SaveLoadProgress.SaveData(result);
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
