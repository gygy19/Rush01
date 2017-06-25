using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGEnemy : GameUnit {

	void Start ()
	{
		base.Start ();	
		
	}

	public void Attack(PlayerController Controller)
	{
		RPGPlayer Player = Controller.RPGPlayer;
		int hitDamage = base.getDamage ();
		Player.damage (hitDamage);
		if (Player.getHp () < 0) {
			Controller.Die ();
		}
	}

	void Update ()
	{
		base.Update ();
	}
}
