using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{

    public GameObject[] raindrops;
    public int numberOfRaindrops;
    public float maxBounds;
    public float minBounds;

    private GameObject raindrop;
    public float winddirection; 

    // Use this for initialization
    void Start()
    {
        raindrops = new GameObject[numberOfRaindrops];
        raindrop = Resources.Load("RainDrop", typeof(GameObject)) as GameObject;
        for (int i = 0; i < numberOfRaindrops; ++i)
        {
            raindrops[i] = Instantiate(raindrop, transform);
            raindrops[i].transform.position = RepositionRaindrop();
            raindrops[i].GetComponent<RainFall>().index = i;
        }
        winddirection = Random.Range(-5.0f, 5.0f);
    }
	// Update is called once per frame
	void Update ()
    {
        for (int i=0; i< numberOfRaindrops; ++i)
        {
            if(raindrops[i].transform.position.y <= -7.0f)
            {
                raindrops[i].transform.position = RepositionRaindrop();
            }
            Vector3 position = raindrops[i].transform.position;
            position.x += winddirection * Time.deltaTime;
            raindrops[i].transform.position = position;
        }
        	
	}

    public void RepositionRaindrop(int index)
    {
        raindrops[index].transform.position = RepositionRaindrop();
    }
    private Vector3 RepositionRaindrop()
    {
        float y = Random.Range(transform.position.y, transform.position.y +5.0f);
        float x = Random.Range(transform.position.x + minBounds, transform.position.x + maxBounds);
        return new Vector3(x,y,0.0f);
    }
}
