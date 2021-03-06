﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_character_controller : MonoBehaviour
{
    public enum EMinigameState : int
    {
        EMainScene = 9,
        EFootball = 0,
        EUmbrella = 1,
        EBallon = 2,
        EStickThrow = 3
    };
    public bool stop = false;
    public bool RunFromAlone = false;
    public Animator animctrl;
    public EMinigameState minigameState;
    public float maxMovementSpeed = 10.0f;
    public float currentMovementSpeed = 2.0f;
    public float acceleration = 100.0f;
    public Vector3 position;
    public Quaternion rotation;
    public float orientation;
    private SceneController controller;

    Vector3 right = new Vector3(1.0f, 0.0f);
    Vector3 up = new Vector3(0.0f, 1.0f);

    public AudioClip goodSound;
    public AudioClip badSound;

    public void SetMinigameState(EMinigameState minigameState)
    {
        Debug.Log("updates State to: " + minigameState);
        this.minigameState = minigameState;
    }

	// Use this for initialization
	void Start ()
    {
        orientation = transform.localScale.x;
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<SceneController>();
        Debug.Log(controller);

        animctrl = gameObject.GetComponent<Animator>();

        //get Position and Rotation Reference
        position = gameObject.transform.position;
        rotation = gameObject.transform.rotation;

        if (DataStorage.chanceRun == 1)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(badSound);
        }
        else
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(goodSound);
        }
    }

    // Update is called once per frame
    void Update ()
    {
		switch(minigameState)
        {
            case EMinigameState.EMainScene:
                Walk();
                break;
            case EMinigameState.EFootball:
                Football();
                break;
            case EMinigameState.EBallon:
                break;
            case EMinigameState.EStickThrow:
                break;
            case EMinigameState.EUmbrella:
                Umbrella_Main();                
                break;
            default:
                break;

        }
	}
    private void Walk()
    {
        if(Input.GetKey("d") || RunFromAlone)
        {
            orientation = transform.localScale.x;
            Debug.Log(orientation);
            animctrl.SetBool("walking", true);
            position.x += currentMovementSpeed * Time.deltaTime;
            if (orientation <= -0.3f)
            {
                Vector3 scale = transform.localScale;
                scale.x = -orientation;
                transform.localScale = scale;
            }
        }
        else if (Input.GetKey("a"))
        {
            orientation = transform.localScale.x;
            Debug.Log(orientation);
            animctrl.SetBool("walking", true);
            position.x -= currentMovementSpeed * Time.deltaTime;
            if (orientation >= 0.3f)
            {
                Vector3 scale = transform.localScale;
                scale.x = -orientation;
                transform.localScale = scale;
            }
        }
        else
        {
            animctrl.SetBool("walking", false);
        }
       
        transform.position = position;

    }
    private void WalkUMbrella()
    {
        if (Input.GetKey("d"))
        {
            orientation = transform.localScale.x;
            animctrl.SetBool("Walking", true);
            position.x += currentMovementSpeed * Time.deltaTime;
            if (orientation <= -0.3f)
            {
                Vector3 scale = transform.localScale;
                scale.x = -orientation;
                transform.localScale = scale;
            }
        }
        else if (Input.GetKey("a"))
        {
            orientation = transform.localScale.x;
            animctrl.SetBool("Walking", true);
            position.x -= currentMovementSpeed * Time.deltaTime;
            if (orientation >= 0.3f)
            {
                Vector3 scale = transform.localScale;
                scale.x = -orientation;
                transform.localScale = scale;
            }
        }
        else
        {
            animctrl.SetBool("Walking", false);
        }

        transform.position = position;

    }
    private void Umbrella_Main()
    {
        if (!stop)
        {
            WalkUMbrella();
        }
        // position += right * movementSpeed;
    }

    void Football()
    {
        Walk();
    }
}
