using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoreApresentation : MonoBehaviour
{
	public int SceneIndex;

	public string[] lore;
	public Text loreTextOnUI;

	public static int i;


    void Update()
    {

		//Texts
		loreTextOnUI.text = lore[i];

		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			++i;
		} else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			--i;
		}

		if(i < 0)
		{
			i = 0;
		} else if (i == lore.Length)
		{
			i = lore.Length - 1;
			SkipToScene();
		}

	}

	public void Forward ()
	{
		if(i < lore.Length - 1)
		{
			i++;
		} else
		{
			SkipToScene();
		}
	}

	public void SkipToScene ()
	{
		SceneManager.LoadSceneAsync(SceneIndex);
		i = 0;
		
	}
}
