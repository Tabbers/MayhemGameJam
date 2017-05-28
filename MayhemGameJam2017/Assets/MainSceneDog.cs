using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneDog : MonoBehaviour
{

    public Sprite[] dog;

    bool bStart = false;
    float pastTime = 0.0f;

    private AudioSource player;

    enum DogState
    {
        Dog1,
        Dog2,
        Dog3,
        Dog4,
    };

    DogState state = DogState.Dog1;
    SpriteRenderer SpriteRend;
    // Use this for initialization
    void Start()
    {
        SpriteRend = GetComponent<SpriteRenderer>();
        player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bStart)
        {
            pastTime += Time.deltaTime;

            if (pastTime > 0.3f)
            {
                if (state == DogState.Dog1)
                {
                    SpriteRend.sprite = dog[0];
                    state = DogState.Dog2;
                }
                else if (state == DogState.Dog2)
                {
                    SpriteRend.sprite = dog[1];
                    state = DogState.Dog3;
                }
                else if (state == DogState.Dog3)
                {
                    SpriteRend.sprite = dog[2];
                    state = DogState.Dog4;
                }
                else if (state == DogState.Dog4)
                {
                    SpriteRend.sprite = dog[1];
                    state = DogState.Dog1;
                }

                pastTime = 0.0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        player.Play();
        bStart = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        player.Stop();
        bStart = false;
    }
}
