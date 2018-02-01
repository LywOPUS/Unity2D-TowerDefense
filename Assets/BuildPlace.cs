using UnityEngine;

public class BuildPlace : MonoBehaviour
{
    private bool _hasBuild;
    [SerializeField] private Tower _tower;

    private void Awake()
    {
        _hasBuild = false;
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