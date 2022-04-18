using UnityEngine;
using System.Collections;
using System;


[RequireComponent(typeof(Rigidbody))]
public class BallMovement : Singleton<BallMovement>
{
    public static Action<float> OnTimerChanged;

    private Rigidbody _ballRigidbody;
    private Transform _cameraTransform;

    [Range(0, 20)]
    [SerializeField] private float _speed;

    [SerializeField] private float _maxTorqueVelocity;

    private float _timer;

    public float Seconds { get; private set; }

    private void OnEnable()
    {
        GameManager.OnGameOver += GameOver;
    }

    private void Start()
    {
        _ballRigidbody = GetComponent<Rigidbody>();
        _cameraTransform = Camera.main.transform;

        _ballRigidbody.maxAngularVelocity = _maxTorqueVelocity;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer>1f)
        {
            _timer -= 1f;
            Seconds += 1f;
            OnTimerChanged?.Invoke(Seconds);
        }
    }

    private void GameOver()
    {
        _ballRigidbody.velocity = Vector3.zero;
        enabled = false;
        StartCoroutine(FreezeTime());
    }

    private IEnumerator FreezeTime()
    {
        for (float i = 0; i < 1; i+=Time.deltaTime)
        {
            yield return null;
        }

        Time.timeScale = 0;
    }

    private void FixedUpdate()
    {
        _ballRigidbody.AddTorque(PlayerInput.Instance.Vertical * _cameraTransform.right * _speed);
        _ballRigidbody.AddTorque(PlayerInput.Instance.Horizontal * -_cameraTransform.forward * _speed);
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= GameOver;
    }
}
