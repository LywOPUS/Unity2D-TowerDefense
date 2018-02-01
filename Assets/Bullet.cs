using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int _Speed;

    public GameObject _target;

    private int _attack;

    private void Start()
    {
        _Speed = 2;
    }


    private void Init()
    {
        _Speed = 3;
        _attack = 1;
    }

    private void Update()
    {
        if (_target == null) 
            return;
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy"))
            return;
        other.GetComponent<Enemy>().GetDamege(_attack);
        ChangeVision(other.gameObject);
        DestroySlef();
    }

    private void DestroySlef()
    {
        ChangeVision(gameObject);
        Destroy(gameObject);
    }

    private void Move()
    {
        var dir = _target.transform.position - transform.position;
        transform.position += dir.normalized * Time.deltaTime * _Speed;
    }

    private static void ChangeVision(GameObject targetGameObject)
    {
        targetGameObject.transform.localScale = Vector3.one * 1.2f;
        //Debug.Log("放大了！！！");
    }
}