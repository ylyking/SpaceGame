﻿using UnityEngine;
using System.Collections;

public class GoalPortal : MonoBehaviour {

	public string levelName;

	private IEnumerator WaitThenExit(float seconds) {
		yield return new WaitForSeconds(seconds);
		GameState.Instance.LoadLevel(levelName);
	}


	void OnTriggerEnter2D(Collider2D collider)
	{
		ShipControls ship = collider.gameObject.GetComponent<ShipControls>();
		if(ship != null){
			ship.deactivateShip();
			GameState.Instance.LastCheckPointNumber = -1;
			CameraFade.StartAlphaFade( Color.black, false, 1.25f, 0.4f, () => { GameState.Instance.LoadLevel(levelName); });
		}
	}
}
