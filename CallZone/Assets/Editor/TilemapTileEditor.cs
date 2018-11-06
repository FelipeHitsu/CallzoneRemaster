using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TilemapTile))]
[CanEditMultipleObjects]
public class TilemapTileEditor : Editor {
	static int desejo = -1;
	public void OnEnable(){
		desejo = (targets[0] as TilemapTile).myTypeIndex;
	}

	public override void OnInspectorGUI(){
		TilemapTile[] myScripts = new TilemapTile[targets.Length];
		for(int i = 0; i < myScripts.Length; i++)
			myScripts[i] = targets[i] as TilemapTile;

		string[] ops = new string[myScripts[0].manager.tiles.Length];
		for(int i = 0; i < ops.Length; i++){
			ops[i] = myScripts[0].manager.tiles[i].name;
		}

		desejo = EditorGUILayout.Popup(desejo, ops);
		if(GUILayout.Button("Aplicar")){
			SceneView.RepaintAll();
			for(int i = 0; i < myScripts.Length; i++){
				myScripts[i].SetTileType(desejo);
			}
		}
	}
}
