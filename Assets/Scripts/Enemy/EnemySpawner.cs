using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _spawnRate;
    [SerializeField] private WaitForSeconds _waitTime;
    [SerializeField] private int _wave;
    public List<Transform> WayPont;

    private void Start()
    {
        _waitTime = new WaitForSeconds(_spawnRate);
        StartCoroutine(SpwanEnemy());
    }

    private IEnumerator SpwanEnemy()
    {
        while (_wave != 0)
        {
            _wave--;
            var enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
            enemy.WayPoint = WayPont;
            //enemy._currentHealth = 2;
            enemy._speed = 1;
            yield return _waitTime;
        }
    }
}