using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour {

    public GameObject[] objects;


	// Use this for initialization
	void Start ()
    {
        int rand = Random.Range(0, objects.Length);
        Instantiate(objects[rand], transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
