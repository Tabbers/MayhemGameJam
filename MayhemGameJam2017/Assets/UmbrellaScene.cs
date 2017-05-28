using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaScene : MonoBehaviour {

    bool bStart = false;
    float pastTime = 0.0f;

    private AudioSource player;

    // Use this for initialization
    void Start () {
        player = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        player.Play();
        bStart = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        player.Stop();
        bStart = false;
    }
}
