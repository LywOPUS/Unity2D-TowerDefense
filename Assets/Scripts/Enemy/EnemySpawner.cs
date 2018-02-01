using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _spawnRate;
    [SerializeField] private WaitForSeconds _waitTime;
    [SerializeField] private int _wave;
    public List<Enemy> EnemyPool;
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
            EnemyPool.Add(Instantiate(_enemy, transform.position, Quaternion.identity));
            _enemy.WayPoint = WayPont;
            _enemy._currentHealth = 100;
            _enemy._speed = 2;
            yield return _waitTime;
        }
    }
}