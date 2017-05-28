using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour {

	public Sprite[] numbers;
	public Image counter;

	public void setNumber(int num)
	{
		if (num <= 3)
			counter.sprite = numbers [num];
	}
}
