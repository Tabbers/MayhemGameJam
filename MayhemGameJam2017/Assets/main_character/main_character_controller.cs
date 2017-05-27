using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_character_controller : MonoBehaviour
{
    public enum EMinigameState : int
    {
        EFootball = 0,
        EUmbrella = 1,
        EBallon,
        EStickThrow
    };

    public EMinigameState minigameState;
    public float movementSpeed = 10.0f;
    public Vector3 position;
    public Quaternion rotation;

    Vector3 right = new Vector3(1.0f, 0.0f);
    Vector3 up = new Vector3(0.0f, 1.0f);

    public void SetMinigameState(EMinigameState minigameState)
    {
        this.minigameState = minigameState;
    }

	// Use this for initialization
	void Start ()
    {
        minigameState = EMinigameState.EFootball;

        //get Position and Rotation Reference
        position = gameObject.transform.position;
        rotation = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update ()
    {
		switch(minigameState)
        {
            case EMinigameState.EFootball:
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
    private void Umbrella_Main()
    {
        position += right * movementSpeed;
    }
}
