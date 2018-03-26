using System;
using UnityEditor;
using UnityEngine;
[Serializable]
[CreateAssetMenu(fileName = "New BackGorundTile", menuName = "MyTile/Tile")]
public class BackGroundTile : RuleTile
{
  private MyTilesType _myTilesType = MyTilesType.green;

  public MyTilesType MyTilesType
  {
    get { return _myTilesType; }
    set { _myTilesType = value; }
  }
}