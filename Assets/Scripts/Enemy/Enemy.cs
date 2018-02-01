using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int _currentHealth;
    private int _currentIndex;
    private Vector3 _FindPos;
    private bool _isDie;
    public int _speed;
    public List<Transform> WayPoint;

    private void Start()
    {
        _isDie = false;
        _currentIndex = 0;
    }

    private void GetDamege(int Damege)
    {
        if (_currentHealth != 0) Die();
        _currentHealth -= Damege;
    }

    private void Die()
    {
        _isDie = true;
        Destroy(gameObject);
    }

    private void Move()
    {
        if (_isDie) return;

        Pathfind();
        var dir = (_FindPos - transform.position).normalized;
        transform.position += dir * Time.deltaTime * _speed;
    }

    private void Pathfind()
    {
        _FindPos = WayPoint[_currentIndex].position;
        if ((transform.position - _FindPos).magnitude < 0.1 &&
            _currentIndex <= WayPoint.Count)
            _currentIndex += 1;
    }

    private void Attack()
    {
        if (_currentIndex == WayPoint.Count) Die();
    }


    private void Update()
    {
        Attack();
        Move();
    }
}