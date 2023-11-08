using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _finalPositionX;
    [SerializeField] private float _speed;

    private float _startPositionX;
    private float _targetPositionX;
    private Vector3 _targetPosition;
    private Coroutine _moving;

    private void Start()
    {
        _startPositionX = transform.position.x;
        _targetPosition = new Vector3(_finalPositionX, 0, 0);
        StartMove();
    }    

    private void SetTargetPosition()
    {
        _targetPositionX = transform.position.x == _finalPositionX ? _startPositionX : _finalPositionX;
        _targetPosition = new Vector3(_targetPositionX, 0, 0);
    }

    private void RestartMove()
    {
        StopMove();
        StartMove();
    }

    private void StartMove()
    {
        _moving = StartCoroutine(Move());
    }

    private void StopMove()
    {
        if (_moving != null)
            StopCoroutine(_moving);
    }

    private IEnumerator Move()
    {
        while (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            yield return null;
        }

        transform.position = _targetPosition;
        SetTargetPosition();
        RestartMove();
    }
}
