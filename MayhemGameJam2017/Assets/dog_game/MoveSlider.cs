using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSlider : MonoBehaviour
{
	public Text value;
	public float speed = 1;
	private Slider slider;
	private bool reverse = false;
	[HideInInspector]
	public float progress = 0;

	// Use this for initialization
	void Start ()
	{
		slider = gameObject.GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!reverse)
		{
			progress += speed * Time.deltaTime;
			if (progress >= 1)
			{
				reverse = true;
			}
		}
		else 
		{
			progress -= speed * Time.deltaTime;
			if (progress <= 0)
			{
				reverse = false;
			}
		}
		slider.value = progress;
		value.text = (slider.value*100).ToString("###");
	}
}
