using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _targetEnemy;
    [SerializeField] private TargetMover _spawnEnemyTemplate;
    [SerializeField] private Vector3 _spawnPoint;

    private float _delay = 2f;

    private void Start()
    {
        StartCoroutine(Generate());
    }

    private void Spawn()
    {
        var enemy = Instantiate(_spawnEnemyTemplate, _spawnPoint, Quaternion.identity);
        enemy.SetTarget(_targetEnemy);
    }

    private IEnumerator Generate()
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {            
            Spawn();
            yield return wait;
        }
    }
}
