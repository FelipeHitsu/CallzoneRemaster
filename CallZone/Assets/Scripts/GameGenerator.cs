using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameGenerator : MonoBehaviour {

    public TextMeshProUGUI roundText;

    private int roundCount = 1;

	// Use this for initialization
	void Start ()
    {
        roundText.CrossFadeAlpha(0, 5f, true);
    }
	
	// Update is called once per frame
	void Update ()
    {
        roundText.text = roundCount.ToString("Round " + roundCount);
		
	}
}
