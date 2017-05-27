using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopbg : MonoBehaviour {

    public GameObject[] bgobjects;
    public int bgCount;
    public GameObject player;
    private main_character_controller controller;
    private float resortDistance = 56.0f;

	// Use this for initialization
	void Start ()
    {
        bgCount = transform.childCount;
        bgobjects = new GameObject[bgCount];
        for(int i=0; i< bgCount; ++i)
        {
            bgobjects[i] = transform.GetChild(i).gameObject;
            bgObjectManager scrpt = bgobjects[i].GetComponent<bgObjectManager>();
            scrpt.rearrangeObjects();
        }
        player = GameObject.FindGameObjectWithTag("MainCharacter");
        controller = player.GetComponent<main_character_controller>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        VoidArrangeBackground();
    }
    void VoidArrangeBackground()
    {
        for(int i=0; i< bgCount; ++i)
        {
            float distanceToCharacter = (player.transform.position - bgobjects[i].transform.position).magnitude;
            if (distanceToCharacter > resortDistance)
            {
                Repositionbg(i);
            }
        }
    }
    void Repositionbg(int index)
    {
        float orientation = controller.orientation;
        if(orientation > 0)
        {
            Vector3 position = bgobjects[index].transform.position;
            position.x += 94;
            bgobjects[index].transform.position = position;
        }
        else
        {
            Vector3 position = bgobjects[index].transform.position;
            position.x -= 94;
            bgobjects[index].transform.position = position;
        }
        bgObjectManager scrpt = bgobjects[index].GetComponent<bgObjectManager>();
        scrpt.rearrangeObjects();
    }

}
