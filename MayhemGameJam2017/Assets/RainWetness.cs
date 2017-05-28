using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainWetness : MonoBehaviour
{
    public float wetness = 0.0f;
    SceneController controller;
    public Rain rain;

    // Use this for initialization
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<SceneController>();
        rain = GameObject.FindGameObjectWithTag("Rain").GetComponent<Rain>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wetness > 50.0f)
        {
            controller.Failed();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "RainDrop")
        {
            int index = other.gameObject.GetComponent<RainFall>().index;
            rain.RepositionRaindrop(index);
            wetness += 0.1f;
        }
    }
}
