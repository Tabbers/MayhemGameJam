using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballBehaviour : MonoBehaviour {
    
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

    public FootballCar car;

    enum FootballStates
    {
        ChildrenPlay,
        ChildrenMissing,
        Stop,
        Die
    };

    FootballStates currentState = FootballStates.ChildrenPlay;

    int counter = 0;
    // Use this for initialization
    void Start() {
        m_centerPosition = transform.position;
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
                    m_degrees = 0.0f;
                }
            } break;
            case FootballStates.ChildrenMissing:
            {
                // Move center along x axis
                float movementY = deltaTime * m_speed * 0.5f;
                m_centerPosition.y += m_direction * movementY;

                // Update degrees
                float degreesPerSecond = 360.0f / m_period;
                m_degrees = Mathf.Repeat(m_degrees + (deltaTime * degreesPerSecond), 360.0f);
                float radians = m_degrees * Mathf.Deg2Rad;

                // Offset by sin wave
                Vector3 offset = new Vector3(-m_amplitude * 0.5f * Mathf.Sin(radians), 0.0f, 0.0f);
                transform.position = m_centerPosition + offset;
                transform.Rotate(Vector3.forward * m_direction * 250.0f * deltaTime);
            }
            break;
            case FootballStates.Stop:
            {
                transform.rotation = Quaternion.identity;
                if (car)
                {
                    car.StartCar();
                }
                
            }
            break;
            case FootballStates.Die:
            {
                pastTime += deltaTime;
                const float dieTime = 0.5f;
                if (pastTime > dieTime && index <= 3)
                {
                    GetComponent<SpriteRenderer>().sprite = array[index++];
                    pastTime -= dieTime;
                }
            } break;
        }
        


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Football_Child1"))
        {
            if (currentState == FootballStates.ChildrenPlay)
            {
                counter++;
            }

            m_direction = 1.0f;
                        
        }
        else if (other.CompareTag("Football_Child2"))
        {
            m_direction = -1.0f;
            counter++;
        }
        else if (other.CompareTag("Street"))
        {
            currentState = FootballStates.Stop;
        }
        else if (other.CompareTag("Car"))
        {
            currentState = FootballStates.Die;
        }
    }
}
