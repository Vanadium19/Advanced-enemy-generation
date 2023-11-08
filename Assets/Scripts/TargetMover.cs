using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _targetTransform;
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetTransform.position, _speed * Time.deltaTime);    
    }

    public void SetTarget(Transform targetTransform)
    {
        _targetTransform = targetTransform;
    }
}
