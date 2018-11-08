using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapTile : MonoBehaviour {
	public TilemapManager manager;
	public int myTypeIndex = -1;

	//setup do tile de acordo com o manager
	public void SetTileType(int typeIndex){
		if(typeIndex < 0 || typeIndex >= manager.tiles.Length){
			Debug.Log("Tipo de tile inválido!");
			return;//retorna pois o indice está fora do tamanho do array
		}
		if(typeIndex == myTypeIndex)
			return;//retorna pois já é do mesmo índice

		myTypeIndex = typeIndex;
		TileType type = manager.tiles[myTypeIndex];
		if(type.sprite != null){
			SpriteRenderer rend = GetComponent<SpriteRenderer>();
			if(rend == null)
				rend = gameObject.AddComponent<SpriteRenderer>();
			rend.sprite = type.sprite;
		}
		else{
			SpriteRenderer rend = GetComponent<SpriteRenderer>();
			if(rend != null)
				DestroyImmediate(rend);
		}

		if(type.state != TileState.Liquid && type.state != TileState.Decal){
			BoxCollider2D coll = GetComponent<BoxCollider2D>();
			if(coll == null)
				coll = gameObject.AddComponent<BoxCollider2D>();
			coll.size = new Vector2 (manager.tileSize.x, manager.tileSize.y);
		}
		else{//não usa collider
			BoxCollider2D coll = GetComponent<BoxCollider2D>();
			if(coll != null)
				DestroyImmediate(coll);
		}

		if(type.canPass)//coloca e um layer que ignora o player
			gameObject.layer = LayerMask.NameToLayer("ignoraPlayer");
	}
}
