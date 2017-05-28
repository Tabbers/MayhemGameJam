using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaScene : MonoBehaviour {

    private SceneController controller;
    bool bStart = false;
    float pastTime = 0.0f;

    private AudioSource player;

    // Use this for initialization
    void Start () {
        player = GetComponent<AudioSource>();
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<SceneController>();
        var collider = GetComponents<BoxCollider2D>();
        if (DataStorage.chanceRun == 1)
        {
            collider[0].enabled = true;
            collider[1].enabled = false;
        }
        else
        {
            collider[0].enabled = false;
            collider[1].enabled = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (DataStorage.chanceRun == 1)
        {
            player.Play();
            bStart = true;
        }
        else
        {
            controller.LoadNextLevel();
        }        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        player.Stop();
        bStart = false;
    }
}
