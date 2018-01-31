using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float _attackIntever; //攻击间隔
    [SerializeField] private int _attackRadius;
    private WaitForSeconds _attackWaitForSeconds;
    [SerializeField] private GameObject _bulletGameObject;
    [SerializeField] private GameObject _bulletTarget;
    private Collider2D _collider2D;
    private List<GameObject> _enemies;
    private GameObject _target;

    private void Start()
    {
        _enemies = new List<GameObject>();
        _attackIntever = 0.5f;
        _attackWaitForSeconds = new WaitForSeconds(_attackIntever);
        StartCoroutine(AttackEnemies());
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;
        Debug.Log("Attack");
        _bulletTarget = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
            _enemies.Remove(other.gameObject);
    }


    private IEnumerator AttackEnemies()
    {
        var timer = 0;
        while (true)
        {
            timer += 1;
            Debug.Log(timer);
            if (timer <= 10) continue;
            if (_bulletTarget != null)
            {
                Instantiate(_bulletGameObject, transform.position, Quaternion.identity);
                _bulletGameObject.GetComponent<Bullet>()._target = _bulletTarget;
            }


            yield return _attackWaitForSeconds;
        }
    }

    private void AttackEnemies(GameObject targetEnemey)
    {
        Instantiate(_bulletGameObject, transform.position, Quaternion.identity);
        _bulletGameObject.GetComponent<Bullet>()._target = _bulletTarget;
    }
}