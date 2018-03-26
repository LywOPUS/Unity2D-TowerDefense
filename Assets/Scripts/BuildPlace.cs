using UnityEngine;

public class BuildPlace : MonoBehaviour
{
    private bool _hasBuild;
    [SerializeField] private GameObject _tower;


    private void Init()
    {
        _hasBuild = false;
    }

    private void Awake()
    {
        Init();
    }

    private void OnMouseUpAsButton()
    {
        if (_hasBuild)
        {
            Debug.Log("hastower");
        }
        else
        {
             Instantiate(_tower, transform.position, Quaternion.identity);
            _hasBuild = true;
        }
    }
}