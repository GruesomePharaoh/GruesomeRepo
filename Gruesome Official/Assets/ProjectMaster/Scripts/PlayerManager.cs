using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*	This script keeps track of the player.
	Created by Brandocks. */

public class PlayerManager : MonoBehaviour {

	//The tutorial that I followed had me create something called a "Singleton."
	//Will research later.

	#region Singleton

	public static PlayerManager instance;

	void Awake() {
		instance = this;
	}

	#endregion

	//GameObject reference to player
	public GameObject player;
}
