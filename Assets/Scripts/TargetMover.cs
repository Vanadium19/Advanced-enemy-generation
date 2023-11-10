using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private GameObject _targetEnemy;
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetEnemy.transform.position,
            _speed * Time.deltaTime);    
    }

    public void SetTarget(GameObject targetEnemy)
    {
        _targetEnemy = targetEnemy;
    }
}
