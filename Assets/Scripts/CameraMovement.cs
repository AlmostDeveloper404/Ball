using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _ballTransform;
    [SerializeField] private float _lerpSpeed;

    private Rigidbody _ballRigidbody;


    private List<Vector3> _velocities = new List<Vector3>();

    private void Start()
    {
        _ballRigidbody = _ballTransform.GetComponent<Rigidbody>();

        for (int i = 0; i < 10; i++)
        {
            _velocities.Add(Vector3.one);
        }
    }

    private void FixedUpdate()
    {
        _velocities.Add(_ballRigidbody.velocity);
        _velocities.RemoveAt(0);
    }

    private void Update()
    {
        Vector3 sum = Vector3.zero;

        for (int i = 0; i < _velocities.Count; i++)
        {
            sum += _velocities[i];
        }

        transform.position = _ballTransform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(sum.x,0f,sum.z)), _lerpSpeed * Time.deltaTime);
    }
}
