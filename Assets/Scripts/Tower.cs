using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tower : MonoBehaviour
{
    [SerializeField] private float _attackIntever; //攻击间隔
    [SerializeField] private int _attackRadius;
    private WaitForSeconds _attackWaitForSeconds;
    [SerializeField] private GameObject _bulletGameObject;

    [SerializeField] private GameObject _bulletTarget;
    private CircleCollider2D _collider2D;
    private List<GameObject> _enemies;

    public int towerID;

    private void Start()
    {
        Init();
        StartCoroutine(AttackEnemies(10));
    }


    private void Init()
    {
        _attackRadius = 1;
        _attackIntever = 0.5f;
        _collider2D = gameObject.GetComponent<CircleCollider2D>();
        _collider2D.radius = _attackRadius;
        _enemies = new List<GameObject>();
        _attackWaitForSeconds = new WaitForSeconds(_attackIntever);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;
        Debug.Log(GetInstanceID() + " Attack " + other.name + " " + other.GetInstanceID());
        _bulletTarget = other.gameObject;
        other.GetComponent<Enemy>().tower = towerID;
    }

//    private void OnTriggerExit2D(Collider2D other)
//    {
//        if (other.CompareTag("Enemy"))
//            _enemies.Remove(other.gameObject);
//    }


    private IEnumerator AttackEnemies(int timer)
    {
        var temp = 0;

        while (true)
        {
            if (temp < timer)
            {
                temp += 1;
                yield return null;
                continue;
            }

            if (_bulletTarget != null)
            {
                var bullet = Instantiate(_bulletGameObject, transform.position, Quaternion.identity);
                bullet.GetComponent<Bullet>()._target = _bulletTarget;
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