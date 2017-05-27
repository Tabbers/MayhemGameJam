using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour {


    public GameObject player;
    public Scene currentScene;

    public const int maxLevelCount = 3;
    public int currentLevel = -1;
    public int[] levels;
	// Use this for initialization
	void Start ()
    {
        levels = new int[maxLevelCount];
        levels[0] = 1;
        levels[1] = 1;
        levels[2] = 1;
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex != 0)
        {
            player = GameObject.FindGameObjectWithTag("MainCharacter");


            switch (currentScene.buildIndex)
            {
                case 0:
                    main_character_controller characterController = player.GetComponent<main_character_controller>();
                    characterController.SetMinigameState(main_character_controller.EMinigameState.EUmbrella);
                    break;
                default:
                    break;
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void LoadLevel(int index)
    {
        currentLevel = index;
        SceneManager.LoadScene(levels[currentLevel]);
    }
    public void LoadNextLevel()
    {
        currentLevel++;
        SceneManager.LoadScene(levels[currentLevel]);
    }
    void Failed()
    {

    }
    void Success()
    {

    }
    
}
