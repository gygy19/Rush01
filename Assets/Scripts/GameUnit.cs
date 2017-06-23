using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit : MonoBehaviour {

	const int MULTIPLICATEURSTRHP = 2;
	const int MULTIPLICATEURINTELMANA = 2;

	private int hp;
	private int exp = 0;
	private int mana;
	private float timeRegenMana = 0;
	[SerializeField]
	private int str, agi, intel, hpBase, regenMana, manaBase;

	protected void Start () {
		this.hp = this.getMaxHp();
		this.mana = this.getMaxMana();
	}
	
	protected void Update () {
		if (this.timeRegenMana >= 1) {
			this.timeRegenMana = 0;
			if (this.mana < this.getMaxMana ()) {
				if (this.mana + this.regenMana <= this.getMaxMana ())
					this.mana += this.regenMana;
				else
					this.mana = getMaxMana ();
			}
			Debug.Log ("mana");
		}
		this.timeRegenMana += Time.deltaTime;
	}
	public int getHp()
	{
		return this.hp;
	}

	public int getMaxHp()
	{
		return this.hpBase + this.str * MULTIPLICATEURSTRHP;
	}

	public int getMaxMana()
	{
		return this.manaBase + this.str * MULTIPLICATEURINTELMANA;
	}

	public int getStr()
	{
		return this.str;
	}

	public int getAgi()
	{
		return this.agi;
	}

	public int getIntel()
	{
		return this.intel;
	}

	public int getLevel()
	{
		return (int)Mathf.Max (Mathf.Floor (8.7f * Mathf.Log ((float)this.exp + 111f) + -40f), 1f);
	}

	public void damage(int damage)
	{
		this.hp -= damage;
	}

	public void addHp(int hp)
	{
		this.hp += hp;
	}

	public void addExp(int exp)
	{
		this.exp += exp;
	}
	public void boostStr()
	{
		this.str++;
	}
	public void boostAge()
	{
		this.str++;
	}
	public void boostIntel()
	{
		this.str++;
	}
}
