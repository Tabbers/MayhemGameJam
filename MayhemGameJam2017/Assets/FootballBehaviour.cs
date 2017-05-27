using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballBehaviour : MonoBehaviour {

    float traveledX;
    Vector3 m_centerPosition;
    float m_degrees;

    float m_direction = 1.0f;

    [SerializeField]
    float m_speed = 1.0f;

    [SerializeField]
    float m_amplitude = 1.0f;

    [SerializeField]
    float m_period = 1.0f;

    // Use this for initialization
    void Start () {
        m_centerPosition = transform.position;
        traveledX = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {

        float deltaTime = Time.deltaTime;

        // Move center along x axis
        float movementX = deltaTime * m_speed;
        m_centerPosition.x += m_direction * movementX;

        // Update degrees
        float degreesPerSecond = 360.0f / m_period;
        m_degrees = Mathf.Repeat(m_degrees + (deltaTime * degreesPerSecond), 360.0f);
        float radians = m_degrees * Mathf.Deg2Rad;

        // Offset by sin wave
        Vector3 offset = new Vector3(0.0f, m_amplitude * Mathf.Sin(radians), 0.0f);
        transform.position = m_centerPosition + offset;

        traveledX += movementX;
        if (traveledX > 15.0f)
        {
            m_direction *= -1;
            traveledX = 0.0f;
        }
    }
}
