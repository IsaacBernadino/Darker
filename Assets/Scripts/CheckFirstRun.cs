using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckFirstRun : MonoBehaviour
{

	public int LoreIntroductionIndex;
	public int MenuIndex;

	float time = 4f;
	float currentTime;

	bool canSwitchScene = false;


	private void Start()
	{
		currentTime = time;

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

			//Do your stuff here
			Debug.Log("Go to Menu");
		}

	}

	private void Update()
	{

		if(Input.GetKey(KeyCode.D))
		{
			PlayerPrefs.DeleteAll();
		}

		if (currentTime <= 0)
		{		
				//Do your stuff here
			if(canSwitchScene) {
				SceneManager.LoadScene(LoreIntroductionIndex);
			} else {
				SceneManager.LoadScene(MenuIndex);
			}
		} else {
			currentTime -= Time.deltaTime;
		}

	}
}
