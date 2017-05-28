using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour {

    public GameObject character;
    public GameObject thing1;
    public GameObject thing2;
    public Sprite sad;

    bool bStart = false;
    float pastTime = 0.0f;

    bool once1 = true;
    bool once2 = true;

    private SceneController controller;
    
    
    // Use this for initialization
    void Start () {
            controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<SceneController>();
    }
	
	// Update is called once per frame
	void Update () {
		if (bStart)
        {
            pastTime += Time.deltaTime;

            if (pastTime > 1.0f && once1)
            {
                once1 = false;
                thing1.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (pastTime > 2.0f && once2)
            {
                once2 = false;
                thing2.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (pastTime > 10.0f)
            {
                controller.LoadNextLevel();
            }
            
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (DataStorage.chanceRun == 1)
        {
            DataStorage.chanceRun = 2;

            gameObject.GetComponent<AudioSource>().Play();
            Destroy(character.GetComponent<main_character_controller>());//.RunFromAlone = false;
            Destroy(character.GetComponent<Animator>());
            character.GetComponent<SpriteRenderer>().sprite = sad;
            bStart = true;
        }
        else
        {
            controller.LoadNextLevel();
        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<AudioSource>().Stop();
    }
}
