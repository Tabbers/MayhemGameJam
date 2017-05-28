using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class umbrella_house : MonoBehaviour {

    GameObject player;
    SceneController controller;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("MainCharacter");
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<SceneController>();
    }
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == player.tag)
        {
            DataStorage.lvl3 = true;
            Debug.Log("Enterd");
            controller.Success();// LoadNextLevel();
        }   
    }

	// Update is called once per frame
	void Update () {
		
	}
}
