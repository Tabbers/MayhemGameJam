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
	public int tries = 3;

	private bool stickShot = false;
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0) && !stickShot && tries >= 0)
		{
			tries--;
			arrowMovement.gameObject.SetActive (false);
			moveSlider.gameObject.SetActive (false);
			playerAnimator.SetTrigger ("throw");
			StartCoroutine (stickThrowAnimation ());
		}
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
