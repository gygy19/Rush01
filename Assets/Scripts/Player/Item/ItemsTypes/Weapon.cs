using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {

	public List<GameObject> weaponModels;

	private int damage;
	private float attackSpeed;
	public int baseDamage;
	public int variationDamage;
	public int levelUpBoostDamage;
	public int baseAttackSpeed;
	public float variatonAttackSpeed;
//	private GameObject skin;

	protected void Start () {
		int rand = Random.Range (0, weaponModels.Count);
		skin = weaponModels [rand];
		base.Start ();
		IEnumerator routine = initializeData (0.1f);
		this.StartCoroutine (routine);
	}

	public IEnumerator initializeData(float waitTime)
	{
		while (true)
		{
			if (RPGPlayer.Player != null) {
				int level = RPGPlayer.Player.GetComponent<RPGPlayer> ().getLevel ();
				damage = baseDamage + Random.Range (-variationDamage, variationDamage + 1) + levelUpBoostDamage * level;

				break;
			}
			yield return new WaitForSeconds(waitTime);
		}
	}
	
	void Update () {
		
	}

	public int getDamage()
	{
		return this.damage;
	}

	public float getAttackSpeed()
	{
		return this.attackSpeed;
	}

	public override bool use()
	{
		return false;
	}
}
