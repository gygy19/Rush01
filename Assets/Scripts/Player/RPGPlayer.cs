using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGPlayer : GameUnit {

	public int[] actif;
	public List<Spell> spells = new List<Spell> ();
	public static GameObject Player;

	void Start () {
		base.Start ();
		Player = this.gameObject;
		actif  = new int[4];
		actif [0] = -1;
		actif [1] = -1;
		actif [2] = -1;
		actif [3] = -1;


		actif [0] = 0;

	}
	
	void Update () {
		base.Update ();
		if (Input.GetKeyDown (KeyCode.Alpha1) && actif[0] != -1)
			this.useSpell (actif[0]);
		if (Input.GetKeyDown (KeyCode.Alpha2) && actif[1] != -1)
			this.useSpell (actif[1]);
		if (Input.GetKeyDown (KeyCode.Alpha3) && actif[2] != -1)
			this.useSpell (actif[2]);
		if (Input.GetKeyDown (KeyCode.Alpha4) && actif[3] != -1)
			this.useSpell (actif[3]);
		if (Input.GetKey(KeyCode.A))
			this.addExp (10);
	}

	public void setSpellActif(int[] spells)
	{
		this.actif = spells;
	}

	public Spell getSpell(int id)
	{
		if (id < spells.Count)
			return spells[id];
		return null;
	}

	public bool useSpell(int id)
	{
		Spell s = this.getSpell (id);
		if (s && this.mana >= s.mana) {
			s.use ();
			this.mana -= s.mana;
		}
		return false;
}
}
