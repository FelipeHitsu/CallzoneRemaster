using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapSelect : MonoBehaviour {
	public static string mapaNome = "";
	public TextMeshProUGUI text;
	string[] maps;
	int curr = 0;
	// Use this for initialization
	void Start () {
		maps = TilemapManager.GetMaps (Application.dataPath + "/Mapas/");
		if (text != null) {
			curr = 0;
			if (maps.Length > 0)
				text.text = maps [0];
			else
				text.text = "NO MAPS FOUND!";
		}
	}
	
	// Update is called once per frame
	void Set (int id) {
		curr = id;
		text.text = maps [curr];
		mapaNome = maps [curr];
	}

	public void Next(){
		Set (++curr >= maps.Length ? 0 : curr);
	}

	public void Prev(){
		Set (--curr < 0 ? maps.Length - 1 : curr);
	}
}
