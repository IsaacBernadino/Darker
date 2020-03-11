using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerMoviments;

public class DisplayCard : MonoBehaviour
{

	public Card card;

	public Text cardName;
	public Text description;
	public Image art;

	public Text cost;

	public PlayerArchitecture targetEffects;

	int type;

	private void Start()
	{
		ShowCard();
	}

	public void ShowCard()
	{
		this.cardName.text = card.name;
		this.cost.text = card.cost.ToString();

		this.description.text = card.description;
		this.art.sprite = card.art;

		GetCardType(card.cardType);
	}

	public int GetCardType(int cardTypeValue)
	{
		if(cardTypeValue == 1)
		{
			type = 1;

		} else if (cardTypeValue == 2)
		{
			type = 2;
		} else if (cardTypeValue == 3)
		{
			type = 3;

		}

		return type;
	}
}
