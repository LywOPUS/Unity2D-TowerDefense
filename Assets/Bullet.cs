using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int _Speed;

    //public int _Attack;
    public GameObject _target;

    private void Start()
    {
        // _Attack = 1;
        _Speed = 2;
        //Vector3.Lerp(transform.position, _target, Time.deltaTime * _Speed);
        // Invoke("DestroySlef", 3);
    }

    private void Update()
    {
        if (_target == null) return;
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;
        Debug.Log("Bullet Attack Enemy");
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
        targetGameObject.transform.localScale = Vector3.one * 2;
        Debug.Log("放大了！！！");
    }
}