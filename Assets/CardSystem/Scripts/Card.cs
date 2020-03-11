using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerMoviments;

[CreateAssetMenu(menuName = "Add Card", fileName = "Card")]
public class Card : ScriptableObject
{

	public int ID;

	public int cost;

	PlayerArchitecture TargetEffects;

	public new string name;
	public Sprite art;

	[TextArea(1, 4)]
	public string description = "This is a card";

	//Valores do effeito
	public float value; // 0 - unused
	public float percent; // 0 - unused


	/// <summary>
	/// cardType define o tipo da carta. Valor int(inteiro). 1 - Ultilitarios, 2 - Defesa, 3 - Agressivos
	/// </summary>
	public int cardType;

	[Tooltip("Values[stamina, cooldown, cooldown%, maxSpeed, maxSpeed%, attack]")]
	[Header("Valores [stamina, cooldown, cooldown%, maxSpeed, maxSpeed%, attack]")]
	public string applyWhere; // Values[stamina, cooldown, maxSpeed, attack]

	[Tooltip("Values[stamina, cooldown, cooldown%, maxSpeed, maxSpeed%, attack]")]
	[Header("Valores [stamina, cooldown, cooldown%, maxSpeed, maxSpeed%, attack]")]
	public bool applyToOther;
	public string other;
	public float valueToOther; // 0 - Unused

	/// <summary>
	/// Adicione todos os parametros para criar uma nova carta
	/// </summary>
	/// <param name="_ID"></param>
	/// <param name="_level"></param>
	/// <param name="_name"></param>
	public void SetValues(int _ID, float _value, float _percent, int _level,
			string _name, string _description, string _where, int _cardType,
			Sprite _art, bool _applyToOther, string _other, float _otherValue)
	{
		ID = _ID;
		cost = _level;

		name = _name;

		percent = _percent;
		value = _value;
		other = _other;
		valueToOther = _otherValue;

		description = _description;

		cardType = _cardType;

		applyToOther = _applyToOther;
		other = _other;
		applyWhere = _where;

		art = _art;
	}

}
