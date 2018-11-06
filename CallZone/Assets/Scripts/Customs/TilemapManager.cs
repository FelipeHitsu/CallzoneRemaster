using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//ok
public enum TileState{
	Solid = 0,
	Liquid,
	Destructible
}

[System.Serializable]
public class TileType{
	public string name = "Nome";
	public Sprite sprite;
	public TileState state = TileState.Solid;
	public bool canPass = false;
}

public class TilemapManager : MonoBehaviour {
	public TileType[] tiles;
	public int width, height;//largura e altura do mapa em tiles
	public Vector2 tileSize;

	void Start(){
		GenerateTiles();
	}

	void Reset(){
		while(transform.childCount > 0)
			DestroyImmediate(transform.GetChild(0).gameObject);
	}
	//Gera os tiles, destrói os existentes se já existirem
	public void GenerateTiles(){
		Reset();

		if(tiles.Length == 0){
			Debug.Log("Não existe nenhum tipo de tile no array!");
			return;//retorna pois não existem tiles no manager
		} 

		for(int y = 0; y < height; y++){
			for(int x = 0; x < width; x++){
				CreateTile (x, -y);
			}
		}
	}

	public TilemapTile CreateTile(int x, int y){
		GameObject obj = new GameObject("tile(" + x + " " + y + ")");
		obj.transform.parent = this.transform;
		obj.transform.localPosition = new Vector2((float)x * tileSize.x, (float)y * tileSize.y);//y invertido pro (0, 0) ficar no topo

		TilemapTile newTile = obj.AddComponent<TilemapTile>();
		newTile.manager = this;
		newTile.SetTileType(0);

		return newTile;
	}

	public void SaveToFile (string path) {
		List<string> tiles = new List<string>();
		for(int i = 0; i < transform.childCount; i++){
			TilemapTile tile = transform.GetChild(i).GetComponent<TilemapTile>();
			if(tile == null)//pula pois tile é nulo
				continue;
			tiles.Add(tile.transform.localPosition.x.ToString("0.00") + " "
					+ tile.transform.localPosition.y.ToString("0.00") + " "
					+ tile.myTypeIndex.ToString("0"));
		}
		File.WriteAllLines(path, tiles.ToArray());
	}

	public void LoadFromFile (string path) {
		Reset();
		string[] tiles = File.ReadAllLines(path);

		for(int i = 0; i < tiles.Length; i++){			
			GameObject obj = new GameObject();
			obj.transform.parent = this.transform;
			float x, y;
			float.TryParse(tiles[i].Split(' ')[0], out x);
			float.TryParse(tiles[i].Split(' ')[1], out y);
			obj.transform.localPosition = new Vector2(x, y);//y invertido pro (0, 0) ficar no topo
			obj.name = "tile(" + x.ToString("0") + " " + (-y).ToString("0") + ")";

			TilemapTile newTile = obj.AddComponent<TilemapTile>();
			newTile.manager = this;
			int type = 0;
			int.TryParse(tiles[i].Split(' ')[2], out type);
			newTile.SetTileType(type);
		}
	}

	public TilemapTile FindTile(int x, int y){
		for (int i = 0; i < this.transform.childCount; i++) {
			Vector3 childPos = transform.GetChild (i).position;
			if (Mathf.RoundToInt (childPos.x / tileSize.x) == x && Mathf.RoundToInt (childPos.y / tileSize.y) == y)
				return transform.GetChild (i).GetComponent<TilemapTile> ();
		}
		return null;
	}
}
