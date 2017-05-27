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

    void SetMinigameState(EMinigameState minigameState)
    {
        this.minigameState = minigameState;
    }

	// Use this for initialization
	void Start ()
    {
        minigameState = EMinigameState.EFootball;
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

    }
}
