using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFall : MonoBehaviour
{
    public int index;
    public float minAcceleration;
    public float maxAcceleration;
    private float acceleration;
    public float velocity;
    public float maxVelocity;
    void OnEnable()
    {
        acceleration = Random.Range(minAcceleration, maxAcceleration);
    }

    void Start()
    {

    }

	// Update is called once per frame
	void Update ()
    {
        Vector3 position = transform.position;
        if (velocity > maxVelocity)
        {
            velocity += acceleration * Time.deltaTime;
        }
        position.y += velocity * Time.deltaTime;
        transform.position = position;
    }
}
