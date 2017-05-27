using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballCar : MonoBehaviour {

    float carSpeed = 10.0f;
    bool bStarted = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (bStarted)
        {
            Vector3 newPosition = transform.position;
            newPosition.x -= carSpeed * Time.deltaTime;
            transform.position = newPosition;

            if (transform.position.x < -50.0f)
            {
                Destroy(gameObject);
            }
        }
	}

    public void StartCar()
    {
        bStarted = true;
    }
}
