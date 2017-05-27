using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonSet : MonoBehaviour {

    public Button btn;
    public SceneController controller;

	// Use this for initialization
	void Start ()
    {
        btn = GameObject.Find("btn_startGame").GetComponent<Button>();
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<SceneController>();
        btn.onClick.AddListener(() => controller.LoadNextLevel());

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
