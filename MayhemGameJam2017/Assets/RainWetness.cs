using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RainWetness : MonoBehaviour
{
    public float wetness = 0.0f;
    SceneController controller;
    public Rain rain;
    Animator animctrl;

    Slider sldr;

    // Use this for initialization
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<SceneController>();
        rain = GameObject.FindGameObjectWithTag("Rain").GetComponent<Rain>();
        animctrl = GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<Animator>();
        sldr = GameObject.FindGameObjectWithTag("UiSlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        sldr.value = wetness;
        if (wetness > 10.0f)
        {
            GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<main_character_controller>().stop = true;
            GameObject.FindGameObjectWithTag("MainCharacter").GetComponentInChildren<Umbrella>().stop = true;
            animctrl.SetBool("Walking", false);
            Invoke("fail", 2.0f);
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
    void fail()
    {
        DataStorage.lvl3 = true;
        controller.Failed();
    }

}
