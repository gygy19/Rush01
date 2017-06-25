using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGPlayer : GameUnit {

	public int[] actif;
	public List<Spell> spells = new List<Spell> ();
	public static GameObject Player;
	private int spellPoints = 0;
	private List<Item> inventory = new List<Item> ();

	public GameObject test;

	void Start () {
		base.Start ();
		Player = this.gameObject;
		actif  = new int[4];
		actif [0] = -1;
		actif [1] = -1;
		actif [2] = -1;
		actif [3] = -1;

		actif [0] = 0;
		actif [1] = 1;
	}
	
	void Update () {
		base.Update ();
		/*if (Input.GetKeyDown (KeyCode.Alpha1) && actif[0] != -1)
			this.useSpell (actif[0]);
		if (Input.GetKeyDown (KeyCode.Alpha2) && actif[1] != -1)
			this.useSpell (actif[1]);
		if (Input.GetKeyDown (KeyCode.Alpha3) && actif[2] != -1)
			this.useSpell (actif[2]);
		if (Input.GetKeyDown (KeyCode.Alpha4) && actif[3] != -1)
			this.useSpell (actif[3]);*/
		if (Input.GetKey(KeyCode.A))
			this.addExp (10);
		/*if (Input.GetKeyDown (KeyCode.E)) {
			test.GetComponent<Item> ().take ();
			this.addItemToInventory (test.GetComponent<Item> ());
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			Debug.Log (this.inventory [0] != null);
			if (this.inventory [0] != null) {
				if (this.inventory [0].use ())
					this.removeItemToInventory (0);
			}
		}*/
	}

	public void setSpellActif(int[] spells)
	{
		this.actif = spells;
	}

	protected override void levelUp()
	{
		base.levelUp ();
		this.spellPoints++;
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

	public bool useSpell(Spell s)
	{
		if (s && this.mana >= s.mana) {
			s.use ();
			this.mana -= s.mana;
		}
		return false;
	}

	public int getSpellPoints()
	{
		return this.spellPoints;
	}

	public bool useSpellPoint(Spell s)
	{
		if (this.spellPoints > 0) {
			this.spellPoints--;
			this.spells[getIdSpell(s)].up ();
			return true;
		}
		return false;
	}

	public int getIdSpell(Spell s)
	{
		int i = 0;
		foreach (Spell spell in this.spells)
		{
			if (s.Equals(spell))
				return i;
			i++;
		}
		return -1;
	}

	public List<Item> getInventory()
	{
		return inventory;
	}

	public void addItemToInventory(Item it)
	{
		UIBannerScript.instance.addItem (it);
		this.inventory.Add (it);
	}

	public void removeItemToInventory(int id)
	{
		UIBannerScript.instance.removeItem (this.inventory[id]);
		this.inventory.RemoveAt (id);
	}

	public void removeItemToInventory(Item it)
	{
		if (this.inventory.Contains (it)) {
			UIBannerScript.instance.removeItem (it);
			this.inventory.Remove (it);
		}
	}
}
