using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awesome : MonoBehaviour {

    private SceneController controller;

	// Use this for initialization
	void Start () {

        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<SceneController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (DataStorage.chanceRun == 2)
        //{
        //    if (other.gameObject.name == "DogScene")
        //    {
        //        controller.LoadNextLevel();
        //    }
        //    else if (other.gameObject.name == "BallScene")
        //    {
        //        controller.LoadNextLevel();
        //    }
        //    else if (other.gameObject.name == "Umbrella")
        //    {
        //        controller.LoadNextLevel();
        //    }
        //}
        
    }
}
