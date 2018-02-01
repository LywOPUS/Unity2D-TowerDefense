using UnityEngine;

public class BuildPlace : MonoBehaviour
{
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

    private static int counter = 1;

    private void OnMouseUpAsButton()
    {
        if (_hasBuild)
        {
            Debug.Log("hastower");
        }
        else
        {
            GameObject tower = Instantiate(_tower, transform.position, Quaternion.identity);
            tower.GetComponent<Tower>().towerID = counter;
            counter++;
            _hasBuild = true;
        }
    }

    private void OpenTowerMenu()
    {
        
    }
}