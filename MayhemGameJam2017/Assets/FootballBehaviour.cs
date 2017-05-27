using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballBehaviour : MonoBehaviour {

    float traveledX;
    float traveledY;
    Vector3 m_centerPosition;
    float m_degrees;

    float m_direction = 1.0f;

    [SerializeField]
    float m_speed = 1.0f;

    [SerializeField]
    float m_amplitude = 1.0f;

    [SerializeField]
    float m_period = 1.0f;

    public Sprite[] array;

    float pastTime = 0.0f;
    int index = 0;

    enum FootballStates
    {
        ChildrenPlay,
        ChildrenMissing,
        Die
    };

    FootballStates currentState = FootballStates.ChildrenPlay;

    int counter = 0;
    // Use this for initialization
    void Start() {
        m_centerPosition = transform.position;
        traveledX = 0.0f;
        GetComponent<SpriteRenderer>().sprite = array[index++];
    }

    // Update is called once per frame
    void Update() {

        float deltaTime = Time.deltaTime;

        switch (currentState)
        {
            case FootballStates.ChildrenPlay:
            {
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
                transform.Rotate(Vector3.back * m_direction * 250.0f * deltaTime);
                    
                if (counter > 3)
                {
                    currentState = FootballStates.ChildrenMissing;
                }
            } break;
            case FootballStates.ChildrenMissing:
            {
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
                transform.Rotate(Vector3.back * m_direction * 250.0f * deltaTime);
            }
            break;
            case FootballStates.Die:
            {
                pastTime += deltaTime;
                if (pastTime > 1.0f && index <= 4)
                {
                    GetComponent<SpriteRenderer>().sprite = array[index++];
                    pastTime -= 1.0f;
                }
            } break;
        }
        


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Football_Child1"))
        {
            m_direction = 1.0f;
            counter++;
        }
        else if (other.CompareTag("Football_Child2"))
        {
            m_direction = -1.0f;
            counter++;
        }
        else if (other.CompareTag("Street"))
        {
            currentState = FootballStates.Die;
        }
    }
}
