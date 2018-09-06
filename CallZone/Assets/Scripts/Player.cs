using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    ///Objetos
    //Os toggles que serão de feedback para o jogador
    public Toggle[] _Tcollectable;
    //Objetos que serão coletados pelo jogador
    public GameObject[] _OCollectables;
    //Objeto para o tiro do jogador
    public GameObject shoot;

    ///Variaveis
    //Velocidade do jogador se mover
    public float speed;
    //Velocidade do jogador virar a base do tank
    public float rotationSpeed;
    //Velocidade para o tiro
    public float fireRate;
    //Angulho para rotação da torre
    float angle;

    ///Vetores
    //Vetor para o tiro com rotação
    Vector3 shootRotation;
    //Vetor para a base do tank
    Vector3 basePosition;
    //Vetor para a torre do tank
    Vector3 baseRotation;
    //Posição onde o tiro irá ser instanciado
    public Transform shootSpawn;
    //Referencia as posições do player
    Transform playerTransform;

    ///Componentes
    //Componente de rigidbody do player
    public Rigidbody2D playerRb;


	// Use this for initialization
	void Start ()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerTransform = transform;
        basePosition = playerTransform.position;
        baseRotation = playerTransform.rotation.eulerAngles;
        shootRotation = baseRotation;

        //Deixando todos os toggles desligados
        for(int i  = 0; i < _Tcollectable.Length; i ++)
        {
            _Tcollectable[i].isOn = false;
        }
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        angle = playerTransform.eulerAngles.magnitude * Mathf.Deg2Rad;

        rotate();

        move();

        Shoot();

    }

   void rotate()
    {
        ///Futuramente: Deixar a rotação com o Joystick, no analógico direito
        
        //Rotação
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            baseRotation.z -= rotationSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            baseRotation.z += rotationSpeed;
        }

        playerTransform.rotation = Quaternion.Euler(baseRotation);
    }

    void move()
    {
        ///Futuramente: Deixar o movimento com o Joystick, no analógico esquerdo

        //Movimento
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        
        if (Input.GetButton("movefoward"))
        {
            
            playerRb.MovePosition(playerTransform.position + playerTransform.right * speed * Time.deltaTime);
        }
       
        if(Input.GetButton("movebackward"))
        {
            
            playerRb.MovePosition(playerTransform.position - playerTransform.right * speed * Time.deltaTime);
        }
    }

    void Shoot()
    {
        fireRate += 0.1f;
        
        ///Furutamente: Deixar esse input para o Joystick, ou seja aqui seria o R1 para atirar.

        //Se apertar click do mouse e o tempo for menor que 1 segundo, atira
        if (Input.GetKeyDown(KeyCode.Mouse0) && fireRate >= 1.0f)
        {
            GameObject tempBullet = Instantiate(shoot, shootSpawn.position, shootSpawn.rotation);
            fireRate = 0;

            Destroy(tempBullet, 4.0f);

        }
    }

    

    void OnCollisionEnter2D(Collision2D collectable)
    {
        if (collectable.gameObject.CompareTag("Milho"))
        {
            setCollectable(5);
            Debug.Log("Milhãoooooooo");
        }
        if (collectable.gameObject.CompareTag("Cenoura"))
        {
            setCollectable(0);
            Debug.Log("Cenoura");
        }
        if (collectable.gameObject.CompareTag("Cogumelo"))
        {
            setCollectable(3);
            Debug.Log("Cogumelo");
        }
        if (collectable.gameObject.CompareTag("Ovo"))
        {
            setCollectable(4);
            Debug.Log("Ovo");
        }
        if (collectable.gameObject.CompareTag("Pao"))
        {
            setCollectable(2);
            Debug.Log("Pao");
        }
        if (collectable.gameObject.CompareTag("Queijo"))
        {
            setCollectable(1);
            Debug.Log("queijo");
        }
    }

    void setCollectable (int index)
    {
        for(int i = 0; i < _Tcollectable.Length; i++)
        {
            _Tcollectable[index].isOn = true;
        }
    }


}


