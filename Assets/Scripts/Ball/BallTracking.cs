using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffSet;
    [SerializeField] private float _lenght;
    private Ball _ball;
    private Beam _beam;
    private Vector3 _cameraPosition;
    private Vector3 _minBallPosition;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();

        _cameraPosition = _ball.transform.position;
        _minBallPosition = _ball.transform.position;

        TrackBall();
    }

    private void Update()
    {
        if(_ball.transform.position.y < _minBallPosition.y)
        {
            TrackBall();
            _minBallPosition = _ball.transform.position;
        }
    }
    private void TrackBall()
    {
        _cameraPosition = _ball.transform.position;
        Vector3 direction = (_beam.transform.position - _ball.transform.position).normalized + _directionOffSet;
        _cameraPosition -= direction * _lenght;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform);
    }
}
