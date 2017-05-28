using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneControl : MonoBehaviour {

    public GameObject character;

    float velocity = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float deltaTime = Time.deltaTime;

        Vector3 pos = character.transform.position;
        pos.x = velocity * deltaTime;
        character.transform.position = pos;
    }
}
