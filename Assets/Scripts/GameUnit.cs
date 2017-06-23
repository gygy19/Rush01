using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit : MonoBehaviour {

	private int hp;
	private int exp = 0;
	private int mana;
	[SerializeField]
	private int str, agi, intel, maxHp, regenMana, manaMax;

	void Start () {
		this.hp = this.maxHp;
		this.mana = this.manaMax;
	}
	
	void Update () {
		if (this.mana < this.manaMax) {
			if (this.mana + this.regenMana <= this.manaMax)
				this.mana += this.regenMana;
			else
				this.mana = manaMax;
		}
	}

	public int getHp()
	{
		return this.hp;
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
