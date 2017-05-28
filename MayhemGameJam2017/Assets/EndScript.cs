using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour {

    public GameObject character;
    public Sprite sad;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(character.GetComponent<main_character_controller>());//.RunFromAlone = false;
        Destroy(character.GetComponent<Animator>());
        character.GetComponent<SpriteRenderer>().sprite = sad;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
    }
}
