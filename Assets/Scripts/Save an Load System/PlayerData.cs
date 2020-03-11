using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerMoviments;

[System.Serializable]
public class PlayerData
{
	public float currentStamina;

	public float[] allItensPickUp;

	public float[] position;

	public PlayerData(PlayerArchitecture player){

		currentStamina = player.currentStamina;

		position = new float[3];
		position[0] = player.transform.position.x;
		position[1] = player.transform.position.y;
		position[2] = player.transform.position.z;

		Debug.Log("Saved...");
	}

}
