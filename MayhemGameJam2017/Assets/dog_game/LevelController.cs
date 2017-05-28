using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	public GameObject stickPrefab;
	public Animator playerAnimator;
	public MoveSlider moveSlider;
	public ArrowMovement arrowMovement;
	public Dog dog;

	public int startObstacleTry = 1;
	public GameObject[] obstacleTries;

	public Counter counter;
	public int tries = 5;
	[HideInInspector]
	public int timesStickReturned = 0;

	private bool stickShot = false;
	private bool finished = false;
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < obstacleTries.Length; i++) 
		{
			if (i == startObstacleTry)
				obstacleTries [i].SetActive (true);
			else
				obstacleTries [i].SetActive (false);
		}

		counter.setNumber (timesStickReturned);
		if (Input.GetMouseButtonDown (0) && !stickShot && tries >= 0 && timesStickReturned < 3)
		{
			tries--;
			arrowMovement.gameObject.SetActive (false);
			moveSlider.gameObject.SetActive (false);
			playerAnimator.SetTrigger ("throw");
			StartCoroutine (stickThrowAnimation ());
		}

		if (timesStickReturned == 3 || tries <= 0 && !finished) 
		{
			finished = true;
			StartCoroutine (finish ());
		}


	}

	private IEnumerator finish()
	{
        DataStorage.lvl1 = true;
		float timePassed = 0;
		while (timePassed < 2) 
		{
			timePassed += Time.deltaTime;
			yield return null;
		}
		SceneController sceneController = GameObject.FindGameObjectWithTag ("Controller").GetComponent<SceneController>();

		if (timesStickReturned == 3) 
		{
			sceneController.Success ();
		}
		else 
		{
			sceneController.Failed ();
		}
			
		yield return null;
	}

	public void enableThrowing()
	{
		arrowMovement.gameObject.SetActive (true);
		moveSlider.gameObject.SetActive (true);
		stickShot = false;
	}

	private IEnumerator stickThrowAnimation()
	{
		while (playerAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.Idle"))
		{
			yield return null;
		}
		while (playerAnimator.GetCurrentAnimatorStateInfo (0).normalizedTime < 0.8f)
		{
			yield return null;
		}

		GameObject stickInstance = Instantiate (stickPrefab, arrowMovement.transform.position, arrowMovement.transform.rotation);
		stickInstance.GetComponent<Stick> ().throwStick (moveSlider.progress);
		dog.stickTransform = stickInstance.transform;

		StartCoroutine (dog.followStick());
		stickShot = true;
	}
}
