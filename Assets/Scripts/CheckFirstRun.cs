using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckFirstRun : MonoBehaviour
{

	public int LoreIntroductionIndex;
	public int MenuIndex;

	float time = 3.5f;
	float currentTime = 0;

	bool canSwitchScene = false;

	public Slider timeSlider;
	public Text txt;

	private void Awake()
	{
		timeSlider.maxValue = time;

		if (PlayerPrefs.GetInt("FirstTimeOpening", 1) == 1)
		{
			Debug.Log("First Time Opening");
			Debug.Log("Go to Lore");
			canSwitchScene = true;
			//Set first time opening to false
			PlayerPrefs.SetInt("FirstTimeOpening", 0);
		} else {
			Debug.Log("NOT First Time Opening");
			canSwitchScene = false;
			Debug.Log("Go to Menu");
		}

	}

	private void Update()
	{

		timeSlider.value = currentTime + 0.55f;
		if(currentTime >= time - 0.75f) {
			txt.text = "Verificado!";
		}

		if(Input.GetKey(KeyCode.D))
		{
			PlayerPrefs.DeleteAll();
		}

		if (currentTime >= time)
		{		
			if(canSwitchScene) {
				SceneManager.LoadScene(LoreIntroductionIndex);
			} else {
				SceneManager.LoadScene(MenuIndex);
			}
		} else {
			currentTime += Time.deltaTime;
		}
	}

}
