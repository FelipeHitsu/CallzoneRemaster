using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TilemapManager))]
public class TilemapManagerEditor : Editor {
	static int selected = 0;
	static string nomeArquivo = "mapa1";
	static Vector3 drawPos;
	static bool delete = false;

	public override void OnInspectorGUI(){
		DrawDefaultInspector();

		TilemapManager myScript = target as TilemapManager;

		if (myScript.tileSize.x == 0.0f)
			myScript.tileSize.x = 1.0f;
		if (myScript.tileSize.y == 0.0f)
			myScript.tileSize.y = 1.0f;

		GUILayout.Space (20);
		if(GUILayout.Button("Gerar"))
			myScript.GenerateTiles();
		GUILayout.BeginHorizontal();
		nomeArquivo = GUILayout.TextField(nomeArquivo);
		if(GUILayout.Button("Salvar"))
			myScript.SaveToFile(Application.dataPath + "/Mapas/" + nomeArquivo + ".czm");
		if(GUILayout.Button("Carregar"))
			myScript.LoadFromFile(Application.dataPath + "/Mapas/" + nomeArquivo + ".czm");
		GUILayout.EndHorizontal();

		GUILayout.Space (20);
		GUILayout.BeginHorizontal ();
		GUILayout.Label("Selecionado: " + (selected != -1 ? myScript.tiles [selected].name : "None"));
		string[] ops = new string[myScript.tiles.Length];
		for(int i = 0; i < ops.Length; i++){
			ops[i] = myScript.tiles[i].name;
		}

		selected = EditorGUILayout.Popup(selected, ops);
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Ferramenta selecionada:");
		if(GUILayout.Button (delete ? "Apagar" : "Pintar"))
			delete = !delete;
		GUILayout.EndHorizontal ();
	}

	//ok

	public void OnSceneGUI(){
		var obj = target as TilemapManager;

		if (Event.current.type == EventType.Layout) 
		{
			HandleUtility.AddDefaultControl(0);
		}
		if (Event.current.type == EventType.MouseMove || Event.current.type == EventType.MouseDrag) {//desenha
			Camera cam = Camera.current;
			Vector3 mousePos = Event.current.mousePosition;
			mousePos.z = -cam.worldToCameraMatrix.MultiplyPoint(obj.transform.position).z;
			mousePos.y = Screen.height - mousePos.y - 36.0f; // ??? Why that offset?!
			mousePos = cam.ScreenToWorldPoint (mousePos);

			mousePos.x /= obj.tileSize.x;
			mousePos.y /= obj.tileSize.y;
			mousePos.x = Mathf.Round (mousePos.x) * obj.tileSize.x;
			mousePos.y = Mathf.Round (mousePos.y) * obj.tileSize.y;

			drawPos = mousePos;
		}
		if ((Event.current.type == EventType.MouseDown || Event.current.type == EventType.MouseDrag) && Event.current.button == 0) {//desenha
			Camera cam = Camera.current;
			Vector3 mousePos = Event.current.mousePosition;
			mousePos.z = -cam.worldToCameraMatrix.MultiplyPoint(obj.transform.position).z;
			mousePos.y = Screen.height - mousePos.y - 36.0f; // ??? Why that offset?!
			mousePos = cam.ScreenToWorldPoint (mousePos);

			int x = Mathf.RoundToInt(obj.transform.position.x + mousePos.x / obj.tileSize.x);
			int y = Mathf.RoundToInt(obj.transform.position.y + mousePos.y / obj.tileSize.y);

			var tile = obj.FindTile (x, y);//tudo invertido nessa parada
			if (delete) {
				if (tile != null)
					DestroyImmediate (tile.gameObject);
			} else {
				if (tile == null)
					tile = obj.CreateTile (x, y);
				tile.SetTileType (selected);
			}
		}

		Handles.color = delete ? Color.red : Color.blue;
		Handles.DrawLine (drawPos - Vector3.right * obj.tileSize.x / 2f + Vector3.up * obj.tileSize.y / 2f, drawPos + Vector3.right * obj.tileSize.x / 2f + Vector3.up * obj.tileSize.y / 2f);
		Handles.DrawLine (drawPos + Vector3.right * obj.tileSize.x / 2f + Vector3.up * obj.tileSize.y / 2f, drawPos + Vector3.right * obj.tileSize.x / 2f - Vector3.up * obj.tileSize.y / 2f);
		Handles.DrawLine (drawPos + Vector3.right * obj.tileSize.x / 2f - Vector3.up * obj.tileSize.y / 2f, drawPos - Vector3.right * obj.tileSize.x / 2f - Vector3.up * obj.tileSize.y / 2f);
		Handles.DrawLine (drawPos - Vector3.right * obj.tileSize.x / 2f - Vector3.up * obj.tileSize.y / 2f, drawPos - Vector3.right * obj.tileSize.x / 2f + Vector3.up * obj.tileSize.y / 2f);
		if (delete) {
			Handles.DrawLine (drawPos - Vector3.right * obj.tileSize.x / 2f + Vector3.up * obj.tileSize.y / 2f, drawPos + Vector3.right * obj.tileSize.x / 2f - Vector3.up * obj.tileSize.y / 2f);
			Handles.DrawLine (drawPos - Vector3.right * obj.tileSize.x / 2f - Vector3.up * obj.tileSize.y / 2f, drawPos + Vector3.right * obj.tileSize.x / 2f + Vector3.up * obj.tileSize.y / 2f);
		} else {
			Color c = Handles.color;
			c.a = 0.5f;
			Handles.color = c;
			Handles.DrawLine (drawPos - Vector3.right * obj.tileSize.x / 2f, drawPos + Vector3.right * obj.tileSize.x / 2f);
			Handles.DrawLine (drawPos - Vector3.up * obj.tileSize.y / 2f, drawPos + Vector3.up * obj.tileSize.y / 2f);
		}
		SceneView.RepaintAll ();
	}
}
