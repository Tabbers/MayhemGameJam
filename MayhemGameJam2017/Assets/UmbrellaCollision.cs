using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaCollision : MonoBehaviour {

    public Rain rain;

    void Start()
    {
        rain = GameObject.FindGameObjectWithTag("Rain").GetComponent<Rain>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "RainDrop")
        {
            int index = other.gameObject.GetComponent<RainFall>().index;
            rain.RepositionRaindrop(index);
        }
    }
}
