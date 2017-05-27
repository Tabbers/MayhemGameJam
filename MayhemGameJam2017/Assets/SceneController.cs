using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour {


    public static SceneController instance = null;

    public GameObject player;
    public Scene currentScene;

    public const int maxLevelCount = 3;
    public int numberOfTravels = 0;
    public int currentLevel = -1;
    public int nextlevel = 0;
    // Use this for initialization

    void Awake()
    {
        if (instance == null)
        {
            Debug.Log("preserved" + gameObject.name);
            //if not, set instance to this
            instance = this;
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
        currentLevel = nextlevel;
        nextlevel = Mathf.FloorToInt(Random.value * 2);
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex != 0)
        {
            player = GameObject.FindGameObjectWithTag("MainCharacter");
            switch (currentScene.buildIndex)
            {
                case 1:
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
        numberOfTravels++;
        SceneManager.LoadScene(index);
    }
    public void LoadNextLevel()
    {
        numberOfTravels++;
        SceneManager.LoadScene(nextlevel);
    }
    public void Failed()
    {

    }
    public void Success()
    {
        LoadNextLevel();
    }
    
}
