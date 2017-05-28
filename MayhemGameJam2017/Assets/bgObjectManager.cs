using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgObjectManager : MonoBehaviour {


    public GameObject[] bgobjects;
    public int bgCount;

    private GameObject[] possibleObjects;
    private Vector3[] relativeObjectSlots;

    // Use this for initialization
    void Start ()
    {
        bgCount = transform.childCount;
        bgobjects = new GameObject[bgCount];
        relativeObjectSlots = new Vector3[5];

        for (int i = 0; i < bgCount; ++i)
        {
            bgobjects[i] = transform.GetChild(i).gameObject;
        }

        relativeObjectSlots[0] = new Vector3(-7.0f, 0.0f, 0.0f);
        relativeObjectSlots[1] = new Vector3(-2.5f, 0.0f, 0.0f);
        relativeObjectSlots[2] = new Vector3(-0.0f, 0.0f, 0.0f);
        relativeObjectSlots[3] = new Vector3(3.5f, 0.0f, 0.0f);
        relativeObjectSlots[4] = new Vector3(7.0f, 0.0f, 0.0f);

        possibleObjects = new GameObject[5];
        possibleObjects[0] = Resources.Load("Bush", typeof(GameObject)) as GameObject;
        possibleObjects[1] = Resources.Load("TreeDark", typeof(GameObject)) as GameObject;
        possibleObjects[2] = Resources.Load("Fence", typeof(GameObject)) as GameObject;
        possibleObjects[3] = Resources.Load("Woman", typeof(GameObject)) as GameObject;
        possibleObjects[4] = Resources.Load("TreeHealthy", typeof(GameObject)) as GameObject;


    }
    public void rearrangeObjects()
    {
       for(int i = 0; i< bgCount; ++i)
       {
            if(bgobjects[i] != null)
            {
              GameObject.Destroy(bgobjects[i]);
            }
            int randomObject = Mathf.FloorToInt(Random.value * 5);
            int randomSlot = Mathf.FloorToInt(Random.value * 5);
            if (randomObject == 0)
            {
                Vector3 offsetPosition = transform.position + relativeObjectSlots[randomSlot];
                offsetPosition.y = -1.5f;
                bgobjects[i] = Instantiate(possibleObjects[randomObject], offsetPosition, new Quaternion());
                Vector3 scale = bgobjects[i].transform.localScale;
                scale.x = Mathf.FloorToInt(Random.value);
                if (Random.value > 0.5f)
                {
                    scale.x = scale.x * -1;
                    bgobjects[i].transform.localScale = scale;
                }
                else
                {
                    bgobjects[i].transform.localScale = scale;
                }
            }
            else if(randomObject == 0)
            {
                Vector3 offsetPosition = transform.position + relativeObjectSlots[randomSlot];
                offsetPosition.y = 1.5f;
                bgobjects[i] = Instantiate(possibleObjects[randomObject], offsetPosition, new Quaternion());
            }
            else if (randomObject == 1)
            {
                Vector3 offsetPosition = transform.position + relativeObjectSlots[randomSlot];
                offsetPosition.y = 1.5f;
                bgobjects[i] = Instantiate(possibleObjects[randomObject], offsetPosition, new Quaternion());
            }
            else if (randomObject == 2)
            {
                Vector3 offsetPosition = transform.position + relativeObjectSlots[randomSlot];
                offsetPosition.y = -1.0f;
                bgobjects[i] = Instantiate(possibleObjects[randomObject], offsetPosition, new Quaternion());
            }
            else if (randomObject == 3)
            {
                Vector3 offsetPosition = transform.position + relativeObjectSlots[randomSlot];
                offsetPosition.y = -1.7f;
                bgobjects[i] = Instantiate(possibleObjects[randomObject], offsetPosition, new Quaternion());
                Vector3 scale = bgobjects[i].transform.localScale;
                if(Random.value > 0.5f)
                {
                    scale.x = scale.x * -1;
                    bgobjects[i].transform.localScale = scale;
                }
                else
                {
                    bgobjects[i].transform.localScale = scale;
                }
                
            }
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
