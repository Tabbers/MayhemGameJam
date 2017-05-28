using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballscene : MonoBehaviour {

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
        bStart = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        bStart = false;
    }
}
