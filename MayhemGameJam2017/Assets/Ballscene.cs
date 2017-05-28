using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballscene : MonoBehaviour {
    private SceneController controller;
    bool bStart = false;
    float pastTime = 0.0f;
    bool bSound = true;

    private AudioSource player;

    public GameObject car;
    public GameObject child1;
    public GameObject child2;
    public GameObject football;

    public Sprite child1Sad;
    public Sprite child2Sad;
    public Sprite ballSad;

    float velocity = 4.0f;
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
		
        if (bStart)
        {
            float deltatime = Time.deltaTime;
            pastTime += deltatime;
            float movement = velocity * deltatime;
            Vector3 pos = car.transform.position;
            pos.x -= movement;
            car.transform.position = pos;

            if (pastTime > 2.0f && bSound)
            {
                bSound = false;
                player.Play();

                child1.GetComponent<SpriteRenderer>().sprite = child1Sad;
                child2.GetComponent<SpriteRenderer>().sprite = child2Sad;
                football.GetComponent<SpriteRenderer>().sprite = ballSad;
            }

        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {   
        
        if (DataStorage.chanceRun == 1)
        {
            bStart = true;
        }
        else
        {
            if (!DataStorage.lvl2)
                controller.LoadNextLevel();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        bStart = false;
    }
}
