using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightManagement : MonoBehaviour
{

	public Light pointLight;
	public static float intencity = 1.6f;
	public static float currentIntencity;
	public static  float multiplier = 0.9f;

	[Space(5)]
	public float TimeToDecrenceIntencity;
	float currentTime;

	[Space(5)]
	public Text lightIntencityInfo;

    void Start()
    {
		currentIntencity = intencity;
		pointLight.intensity = currentIntencity;

		currentTime = TimeToDecrenceIntencity;
    }

    // Update is called once per frame
    void Update()
    {

    	//UI
    	lightIntencityInfo.text = "Itencidade da luz de auxilio: " + currentIntencity;


		pointLight.intensity = currentIntencity;
		// Verificadores
		if (pointLight.intensity <= 0.44f)
		{
			pointLight.intensity = 0.44f;  //Valor fixo
		}

		if (currentTime <= 0 && pointLight.intensity >= 0.45f)
		{
			currentIntencity /= 1.4f;
			currentTime = TimeToDecrenceIntencity;
		}
		else if (pointLight.intensity >= 0.45f)
		{
			currentTime -= Time.deltaTime;
		}

	}

}

