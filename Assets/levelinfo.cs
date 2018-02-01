using System.Collections.Generic;
using UnityEngine;

public class levelinfo : MonoBehaviour
{
    public static int Wave;
    public static List<Transform> WayPoints;
    public Transform Path;

    public void Start()
    {
        Path = transform.Find("Grid/Path");
        Debug.Log(Path);
        GetWayPoint();
    }

    private void GetWayPoint()
    {
        foreach (Transform child in Path)
            //WayPoints.Add(child);
            Debug.Log(Path);
    }
}