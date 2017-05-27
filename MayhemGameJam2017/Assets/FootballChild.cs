using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballChild : MonoBehaviour
{

    public float direction;

    public Sprite happy;
    public Sprite sad;

    private float speed = 2.0f;

    Vector3 position;
    float distance = 0.0f;

    enum ChildState
    {
        NONE,
        FORWARDS,
        BACKWARDS
    };

    ChildState current = ChildState.NONE;
    // Use this for initialization
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float deltaTime = Time.deltaTime;
        float movement = deltaTime * speed;

        if (current == ChildState.FORWARDS)
        {
            position.x += movement * direction;
            transform.position = position;
            distance += movement;
            if (distance > 0.5f)
            {
                current = ChildState.BACKWARDS;
                distance = 0.0f;
            }
        }
        else if (current == ChildState.BACKWARDS)
        {
            position.x += movement * direction * -1.0f;
            transform.position = position;
            distance += movement;
            if (distance > 0.5f)
            {
                current = ChildState.NONE;
                distance = 0.0f;
            }
        }
    }

    public void MakeHappy()
    {
        if (happy)
        {
            GetComponent<SpriteRenderer>().sprite = happy;
        }
    }

    public void MakeSad()
    {
        if (sad)
        {
            GetComponent<SpriteRenderer>().sprite = sad;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Football"))
            current = ChildState.FORWARDS;
    }
}
