using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _timerText;

    private void OnEnable()
    {
        BallMovement.OnTimerChanged += UpdateTimer;
    }

    public void UpdateTimer(float _timer)
    {
        _timerText.text = _timer.ToString("0");
    }

    private void OnDisable()
    {
        BallMovement.OnTimerChanged -= UpdateTimer;
    }
}
