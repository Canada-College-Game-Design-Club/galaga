using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpBar : MonoBehaviour
{

	public Slider powerTime;
	public Slider rapidFireTime;


	public void SetMaxTime(float time)
	{
		powerTime.maxValue = time;
		powerTime.value = time;

	}

	public void SetTime(float time)
	{
		powerTime.value = time;

	}


}
