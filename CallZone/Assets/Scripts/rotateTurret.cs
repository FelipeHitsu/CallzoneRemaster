using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateTurret : MonoBehaviour {

    [SerializeField]
    private GameObject shoot;

    public Transform shootspawn;

	
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

    
    public void Shoot()
    {
        ///Furutamente: Deixar esse input para o Joystick, ou seja aqui seria o R1 para atirar.

        //Se apertar click do mouse e o tempo for menor que 2 segundos, atira
        GameObject tempBullet = Instantiate(shoot, shootspawn.position, Quaternion.identity);
        tempBullet.transform.right = transform.right;

        Destroy(tempBullet, 4.0f);

        
    }
}
