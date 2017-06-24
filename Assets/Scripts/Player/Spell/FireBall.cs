using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.PyroParticles;

public class FireBall : Spell {

	public GameObject ball;
	public int damage;
	public int variationDamage;
	public int LevelUpBoost;

	void Start () {
		base.Start ();
	}
	
	void Update () {
		base.Update ();
	}

	public override void use()
	{
		Vector3 pos = RPGPlayer.Player.transform.position;
		pos.y += 4;
		GameObject fire = GameObject.Instantiate(ball, pos, Quaternion.LookRotation(Constants.GetMousePosition() - RPGPlayer.Player.transform.position));
		RPGPlayer.Player.GetComponent<PlayerController> ().StopMovement ();
		RPGPlayer.Player.transform.rotation = Quaternion.LookRotation(Constants.GetMousePosition() - RPGPlayer.Player.transform.position);
	}

	public override string getValue()
	{
		return "[" + (damage - variationDamage) + " - " + (damage + variationDamage) + "]";
	}

	public override string getUpgrade()
	{
		return "[" + (damage - variationDamage + LevelUpBoost * this.getLevel()) + " - " + (damage + variationDamage + LevelUpBoost * this.getLevel()) +  "]";
	}
}
