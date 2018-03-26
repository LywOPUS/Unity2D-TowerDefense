using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BackGroundTileEditor : RuleTileEditor {
	[CustomEditor(typeof(BackGroundTile))]  
	[CanEditMultipleObjects]  
	public class SrpgTileEditor : RuleTileEditor  
	{  
		public BackGroundTile BackGroundTile { get { return target as BackGroundTile; } }  
  
		public override void OnInspectorGUI()  
		{  
			// 渲染新增的数据  
			EditorGUI.BeginChangeCheck();  
			BackGroundTile.MyTilesType = (MyTilesType)EditorGUILayout.EnumPopup("Terrain Type", BackGroundTile.MyTilesType);  
			if (EditorGUI.EndChangeCheck())  
			{  
				EditorUtility.SetDirty(target);  
			}  
  
			// 渲染RuleTile的内容  
			EditorGUILayout.Space();  
			base.OnInspectorGUI();  
		}  
	}  
}  

