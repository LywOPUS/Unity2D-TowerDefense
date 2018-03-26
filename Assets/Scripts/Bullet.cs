using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _speed;

    public GameObject Target { get; set; }

    [SerializeField] private int _attack;


    private void Start()
    {
        Init();
    }


    private void Init()
    {
        _speed = 3;
        _attack = 1;
    }

    private void Update()
    {
        if (Target == null)
            return;
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy"))
            return;
        other.GetComponent<Enemy>().GetDamege(_attack);//TODO: 对Enemy类有依赖，这里需要修改对enemy的调用
//        ChangeVision(other.gameObject);
        DestroySlef();
    }

    private void DestroySlef()
    {
        ChangeVision(gameObject);
        Destroy(gameObject);
    }

    private void Move()
    {
        var dir = Target.transform.position - transform.position;
        transform.position += dir.normalized * Time.deltaTime * _speed;
    }

    private static void ChangeVision(GameObject targetGameObject)
    {
        targetGameObject.transform.localScale = Vector3.one * 1.2f;
    }
}