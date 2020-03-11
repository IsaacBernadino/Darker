using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{


	public GameObject[] CardView;

	public void ShowTree(int TreeID)
	{
		if (TreeID == 0)
		{
			//for (int i = 0; i < onHand.Length; i++)
			//{
			//	onHand[i].SetActive(true);
			//}
			CardView[0].SetActive(true);
			CardView[1].SetActive(false);
			CardView[2].SetActive(false);
		}
		else if (TreeID == 1)
		{
			CardView[1].SetActive(true);
			CardView[0].SetActive(false);
			CardView[2].SetActive(false);
		}
		else if (TreeID == 2)
		{
			CardView[2].SetActive(true);
			CardView[0].SetActive(false);
			CardView[1].SetActive(false);
		}
	}

}
