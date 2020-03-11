using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerMoviments;
public class ViewCards : MonoBehaviour
{

	public PlayerArchitecture player;
	public PtManager credits;
	public Card[] card;
	public GameObject[] onHand;
	public Button[] btn;

	public GameObject[] UsedBG;

	public RawImage[] cantUse;

	int i;

	private void Start()
	{

	}

	void Update()
	{
		for (i = 0; i < card.Length; i++)
		{
			if (credits.points < card[i].cost)
			{
				cantUse[i].enabled = true;
			} else
			{
				cantUse[i].enabled = false;
			}
		}

	}

	public void ApplyEffect(int cardIndex)
	{
		if (credits.points >= card[cardIndex].cost)
		{

			// Debug.Log("Card " + cardIndex + " Used");
			btn[cardIndex].enabled = false; //Desativa o botão para evitar spawn de efeitos
			UsedBG[cardIndex].SetActive(true);

			if(card[cardIndex].value != 0)
			{
				player.ApplyCardEffect(card[cardIndex].value, card[cardIndex].applyWhere,
					card[cardIndex].valueToOther, card[cardIndex].other, card[cardIndex].applyToOther);
			}
			if (card[cardIndex].percent != 0)
			{
				player.ApplyCardEffect(card[cardIndex].percent, card[cardIndex].applyWhere,
					card[cardIndex].valueToOther, card[cardIndex].other, card[cardIndex].applyToOther);
			}
			if (card[cardIndex].percent == 0 && card[cardIndex].percent == 0)
			{
				Debug.Log("EFEITOS MULTIPLOS OU SEM EFEITOS");
			}

			credits.UsedPoints(card[cardIndex].cost);
		}
	}
}
