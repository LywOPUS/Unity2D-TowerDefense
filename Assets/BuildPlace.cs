using UnityEngine;

public class BuildPlace : MonoBehaviour
{
    private static int counter = 1;
    private bool _hasBuild;
    [SerializeField] private GameObject _tower;


    private void init()
    {
        _hasBuild = false;
    }

    private void Awake()
    {
        init();
    }

    private void OnMouseUpAsButton()
    {
        if (_hasBuild)
        {
            Debug.Log("hastower");
        }
        else
        {
            var tower = Instantiate(_tower, transform.position, Quaternion.identity);
            counter++;
            _hasBuild = true;
        }
    }

    private void OpenTowerMenu()
    {
    }
}