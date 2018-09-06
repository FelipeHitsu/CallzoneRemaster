using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateTurret : MonoBehaviour {

 

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        rotate();	
	}

    void rotate()
    {
        ///Futuramente: Deixar a rotação com o Joystick, no analógico direito

        //Rotação
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.right = direction;
    }
}
