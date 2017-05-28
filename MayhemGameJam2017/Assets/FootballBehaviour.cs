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

    float pastTime = 0.6f;
    int index = 0;

    int winCount = 0;

    bool hasWon = false;
    bool hasLose = false;
    float wontime = 0.0f;

    public FootballCar car;
    public FootballChild child1;
    public FootballChild child2;
    public main_character_controller character;

    public AudioClip bounce;
    public AudioClip pop;
    private SceneController controller;
    private AudioSource player;
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
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<SceneController>();
        player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

        float deltaTime = Time.deltaTime;

        if (hasWon)
        {
            wontime += deltaTime;
            if (wontime > 2.0f)
            {
                DataStorage.lvl2 = true;
                controller.Success();
            }
        }
        else if (hasLose)
        {
            wontime += deltaTime;
            if (wontime > 2.0f)
            {
                DataStorage.lvl2 = true;
                controller.Failed();
            }
        }
        if (!hasWon)
        {
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
                            m_direction = 1.0f;
                            currentState = FootballStates.ChildrenMissing;
                            m_degrees = 0.0f;
                        }
                    }
                    break;
                case FootballStates.ChildrenMissing:
                    {
                        // Move center along x axis
                        float movementY = deltaTime * m_speed * 0.5f;
                        m_centerPosition.y += m_direction * movementY;

                        // Offset by sin wave
                        Vector3 offset = new Vector3(-m_amplitude * 0.08f, 0.0f, 0.0f);
                        transform.position = m_centerPosition;
                        transform.Rotate(Vector3.forward * 250.0f * deltaTime);
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
                        else if (index == 4)
                        {
                            if (child1 && child2)
                            {
                                child1.MakeSad();
                                child2.MakeSad();
                            }

                            index++;
                        }
                    }
                    break;
            }
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        player.PlayOneShot(bounce);
        if (other.CompareTag("Football_Child1"))
        {
            if (winCount < 3)
            {
                currentState = FootballStates.ChildrenPlay;
                counter++;

                m_direction = 1.0f;
            }
            else
            {
                child1.MakeHappy();
                child2.MakeHappy();
                //Destroy(this);
                hasWon = true;
            }           
        }
        else if (other.CompareTag("Football_Child2"))
        {
            if (winCount < 3)
            {
                currentState = FootballStates.ChildrenPlay;
                counter++;

                m_direction = -1.0f;
            }
            else
            {
                child1.MakeHappy();
                child2.MakeHappy();
                //Destroy(this);
                hasWon = true;
            }
        }
        else if (other.CompareTag("Street"))
        {
            currentState = FootballStates.Stop;
        }
        else if (other.CompareTag("Car"))
        {
            player.PlayOneShot(pop);
            currentState = FootballStates.Die;
            hasLose = true;
        }
        else if (other.CompareTag("MainCharacter"))
        {
            m_direction = -1.0f;
            counter = 0;
            winCount++;
        }
    }
}
