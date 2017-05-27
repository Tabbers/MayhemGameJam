using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour 
{
	void Start()
	{
	}

	public void throwStick(float velocity)
	{
		Vector3 rotatedNormalizedVector = gameObject.transform.rotation * Vector2.right;
		rotatedNormalizedVector.Normalize();
		Vector2 forceVector = rotatedNormalizedVector * (velocity * 800);
		gameObject.GetComponent<Rigidbody2D>().AddForce(forceVector);
	}
}
