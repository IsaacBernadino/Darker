using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

	public int NewGameSceneIndex;

	public GameObject[] panels;
	bool switchValue;
	public GameObject continueBtn;

	public Slider volumeSlider;

	void Start () {
		volumeSlider.value = 0.5f;
	}
	void Update () {
		AudioListener.volume = volumeSlider.value;

		string path =  Application.persistentDataPath + "/player.drt";
		if(File.Exists(path)) {
			continueBtn.SetActive(true);
			//Debug.Log("Save exists in current folder: " + path);
		}
	}

	public void NewGame ()
	{
		SceneManager.LoadSceneAsync(NewGameSceneIndex);
	}


	public void ShowPanel(int panelId) 
	{
		panels[panelId].SetActive(true);
	}

	public void ClosePanel (int panelId)
	{
		panels[panelId].SetActive(false);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
