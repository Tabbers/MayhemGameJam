using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour {


    public static SceneController instance = null;

    public GameObject player;
    public Scene currentScene;
    // Use this for initialization

    void Awake()
    {
        if (instance == null)
        {
            Debug.Log("preserved" + gameObject.name);
            //if not, set instance to this
            instance = this;
            DataStorage.MyShit();
            SceneManager.sceneLoaded += OnLevelFinishedLoading;
            DontDestroyOnLoad(gameObject);            
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            Debug.Log("destoried" + gameObject.name);
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
    } 
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex != 0)
        {
            player = GameObject.FindGameObjectWithTag("MainCharacter");
            main_character_controller characterController = player.GetComponent<main_character_controller>();
            switch (currentScene.buildIndex)
            {
                case 1:
                    characterController.SetMinigameState(main_character_controller.EMinigameState.EMainScene);
                    if (DataStorage.laseScene == 2)
                    {
                        var dog = GameObject.Find("DogScene");
                        Vector3 pos = player.transform.position;
                        pos.x = dog.transform.position.x;
                        player.transform.position = pos;
                    }
                    else if (DataStorage.laseScene == 3)
                    {
                        GameObject dog = GameObject.Find("BallScene");
                        dog.GetComponent<BoxCollider2D>().enabled = false;
                        Vector3 pos = player.transform.position;
                        pos.x = dog.transform.position.x;
                        player.transform.position = pos;
                    }
                    else if (DataStorage.laseScene == 4)
                    {
                        GameObject dog = GameObject.Find("UmbrellaScene");
                        dog.GetComponent<BoxCollider2D>().enabled = false;
                        Vector3 pos = player.transform.position;
                        pos.x = dog.transform.position.x;
                        player.transform.position = pos;
                    }

                        break;
                case 4:                    
                    characterController.SetMinigameState(main_character_controller.EMinigameState.EUmbrella);
                    break;
                case 3:
                    characterController.SetMinigameState(main_character_controller.EMinigameState.EFootball);
                    break;
                case 2:
                    characterController.SetMinigameState(main_character_controller.EMinigameState.EStickThrow);
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
        DataStorage.currentLevel++;
        if (DataStorage.currentLevel < DataStorage.maxNumberOfLevels)
        {
            SceneManager.LoadScene(index);
        }
    }
    public void LoadNextLevel()
    {
        DataStorage.currentLevel++;
        if (DataStorage.currentLevel < DataStorage.maxNumberOfLevels)
        {
            SceneManager.LoadScene(DataStorage.levels[DataStorage.currentLevel]);
        }
    }
    public void Failed()
    {
        DataStorage.laseScene = currentScene.buildIndex;
        LoadNextLevel();
    }
    public void Success()
    {
        DataStorage.laseScene = currentScene.buildIndex;
        DataStorage.happines++;
        LoadNextLevel();
    }
    
}
