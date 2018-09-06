using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    
    public float speed;

    public Rigidbody2D bulletRb;

    // Use this for initialization
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        bulletRb.MovePosition(transform.position + transform.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("pedroso"))
        {
            Destroy(gameObject);
        }
    }

    

}
