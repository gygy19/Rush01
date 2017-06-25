using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(Weapon))]
public class WeaponEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		Weapon myScript = (Weapon)target;
		if(GUILayout.Button("save skin localTransform presets"))
		{
			myScript.localPosition = myScript.skin.transform.localPosition;
			myScript.localRotation = myScript.skin.transform.localRotation;
		}
	}
}
#endif

public class Weapon : Item {

	public List<GameObject> weaponModels;

	private int damage;
	private float attackSpeed;
	public int baseDamage;
	public int variationDamage;
	public int levelUpBoostDamage;
	public int baseAttackSpeed;
	public float variatonAttackSpeed;

	public Vector3 localPosition;
	public Quaternion localRotation;

//	private GameObject skin;

	protected void Start () {
//		int rand = Random.Range (0, weaponModels.Count);
//		skin = weaponModels [rand];
//		base.Start ();
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
		RPGPlayer player = RPGPlayer.Player.GetComponent<RPGPlayer> ();
		player.equipWeapon (this);
		player.equipItem (this);
//		skin.transform.localRotation = localRotation;
//		skin.transform.localPosition = localPosition;
		return true;
	}
}
