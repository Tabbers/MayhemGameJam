using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour 
{
	[HideInInspector]
	public float force;
	public float speed = 2;
	public GameObject stickPrefab;

	private bool stickShot = false;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		diff.Normalize();

		float rot_z = Mathf.Clamp(Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg, -30, 70);
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

		if (Input.GetMouseButtonDown (0) && !stickShot)
		{
			GameObject stickInstance = Instantiate (stickPrefab, transform.position, transform.rotation);
			stickInstance.GetComponent<Stick> ().throwStick (force);
			stickShot = true;
		}
	}
}
