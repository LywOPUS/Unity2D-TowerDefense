using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float _attackIntever; //攻击间隔
    [SerializeField] private int _attackRadius;
    private WaitForSeconds _attackWaitForSeconds;
    [SerializeField] private GameObject _bulletGameObject;

    private CircleCollider2D _collider2D;


    private List<GameObject> EnemyTargetList;


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
        _attackWaitForSeconds = new WaitForSeconds(_attackIntever);
        EnemyTargetList = new List<GameObject>();

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;
        if (!EnemyTargetList.Contains(other.gameObject))
            EnemyTargetList.Add(other.gameObject);
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) EnemyTargetList.Remove(other.gameObject);
    }

    private IEnumerator AttackEnemies(float timer)
    {
        var temp = 0f;

        while (true)
        {
            if (temp < timer)
            {
                temp += 1.0f*Time.deltaTime;
                //Debug.Log(temp);
                yield return null;
                continue;
            }

            if (EnemyTargetList.Count != 0)
            {
                SpawnBullet(EnemyTargetList[0]);
            }

            yield return _attackWaitForSeconds;
        }
    }


    private void SpawnBullet(GameObject bulletTarget)
    {
        var bullet = Instantiate(_bulletGameObject, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Target = bulletTarget;//TODO:这里直接修改了bullet类的属性
    }

    
}