using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour 
{
	[HideInInspector]
	public Transform stickTransform;
	public float speed;

	private BoxCollider2D collider;
	private Animator animator;
	private bool hasCollided = false;

	// Use this for initialization
	void Start ()
	{
		collider = gameObject.GetComponent<BoxCollider2D>();
		animator = gameObject.GetComponent<Animator>();
	}

	public IEnumerator followStick()
	{
		if (stickTransform != null)
		{
			while (transform.position.x > stickTransform.position.x) {yield return null;}
			while (!hasCollided && transform.position.x < stickTransform.position.x && !hasCollided)
			{
				animator.SetBool ("IsWalking", true);
				transform.position = new Vector3 (transform.position.x + Time.deltaTime * speed, transform.position.y);
				yield return null;
			}
			animator.SetBool ("IsWalking", false);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer != 8)
		{
			hasCollided = true;
		}
	}
}
