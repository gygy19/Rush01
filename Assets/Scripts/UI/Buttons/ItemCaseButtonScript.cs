using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;

public class ItemCaseButtonScript : AbstractCaseButton {
	
	public bool isSelected = false;
	public bool active = true;
	public bool onDrop = false;
	public Sprite blankSprite;

	public Item item = null;
	//ITEM

	private bool ondrag = false;

	// Use this for initialization
	void Start () {
		base.Update ();
	}

	// Update is called once per frame
	void Update () {
		base.Update ();
	}

	public override void addSpell(Spell spell) {
		
	}

	public override void removeSpell() {
		
	}

	public override void addItem(Item item) {
		this.item = item;
		this.GetComponent<Image> ().sprite = item.icon;
	}

	public override void removeItem() {
		this.item = null;
		this.GetComponent<Image> ().sprite = blankSprite;
	}
}
