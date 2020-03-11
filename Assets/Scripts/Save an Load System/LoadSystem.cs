using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerMoviments;

public class LoadSystem : MonoBehaviour
{

	public PlayerArchitecture player;

	public void Load () {
		player.GetLoad();
	}

}
