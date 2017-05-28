using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour 
{
	[HideInInspector]
	public Transform stickTransform;
	public float speed;
	public Transform mouthTransform;
	public LevelController levelController;

	private BoxCollider2D collider;
	private Animator animator;
	private AudioSource audioSource;
	private bool hasCollided = false;
	private bool collidedWithStick = false;

	// Use this for initialization
	void Start ()
	{
		collider = gameObject.GetComponent<BoxCollider2D>();
		animator = gameObject.GetComponent<Animator>();
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

	public IEnumerator followStick()
	{
		if (stickTransform != null)
		{
			audioSource.Play ();
			animator.SetBool ("Sit", false);
			animator.SetBool ("Sad", false);
			transform.rotation = Quaternion.identity;
			while (transform.position.x > stickTransform.position.x) {yield return null;}
			while (!hasCollided && transform.position.x < stickTransform.position.x && !hasCollided)
			{
				animator.SetBool ("IsWalking", true);
				transform.position = new Vector3 (transform.position.x + Time.deltaTime * speed, transform.position.y);
				yield return null;
			}
			animator.SetBool ("IsWalking", false);
		}
		if (collidedWithStick)
			StartCoroutine (returnToPlayerWithStick ());
		else
			StartCoroutine (returnToPlayerWithoutStick ());
		yield return null;
	}

	public IEnumerator returnToPlayerWithStick()
	{
		transform.Rotate (new Vector3 (0, 180));
		stickTransform.position = mouthTransform.position;

		while (transform.position.x > -4f) 
		{
			animator.SetBool ("IsWalking", true);
			transform.position = new Vector3 (transform.position.x - Time.deltaTime * speed, transform.position.y);
			stickTransform.position = mouthTransform.position;
			yield return null;
		}
		animator.SetBool ("IsWalking", false);
		animator.SetBool ("Sit", true);
		transform.rotation = Quaternion.Euler (Vector3.up);
		transform.Rotate (new Vector3 (0, 180, 0));
		Destroy (stickTransform.gameObject);
		hasCollided = false;
		collidedWithStick = false;
		levelController.timesStickReturned++;

		if (levelController.tries <= 0 && levelController.timesStickReturned < 3) 
		{
			animator.SetBool ("Sad", true);
		} 
		if (levelController.tries > 0 && levelController.timesStickReturned < 3)
		{
			levelController.startObstacleTry = Mathf.RoundToInt(Random.value * 2);
			levelController.enableThrowing ();
		}

		yield return null;
	}

	private IEnumerator returnToPlayerWithoutStick()
	{
		transform.Rotate (new Vector3 (0, 180, 0));
		while (transform.position.x > -4f) 
		{
			animator.SetBool ("IsWalking", true);
			transform.position = new Vector3 (transform.position.x - Time.deltaTime * speed, transform.position.y);
			yield return null;
		}
		animator.SetBool ("IsWalking", false);
		transform.rotation = Quaternion.Euler (Vector3.up);

		if (levelController.tries <= 0) 
		{
			animator.SetBool ("Sad", true);
			transform.Rotate (new Vector3 (0, 180, 0));
		} 
		else 
		{
			levelController.startObstacleTry = Mathf.RoundToInt(Random.value * 2);
			Debug.Log (levelController.startObstacleTry);
			levelController.enableThrowing ();
		}
		Destroy (stickTransform.gameObject);
		hasCollided = false;
		collidedWithStick = false;


		yield return null;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer != 8)
		{
			if (collision.gameObject.tag == "Stick")
			{
				collidedWithStick = true;
				collision.collider.enabled = false;
				Destroy (collision.rigidbody);
			}
			hasCollided = true;
		}
	}
}
