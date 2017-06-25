using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;

public abstract class AbstractCaseButton : MonoBehaviour, IPointerClickHandler, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {

	public bool isSelected = false;
	public bool active = true;
	public bool onDrop = false;
	public Sprite blankSprite;

	public Item item = null;
	public Spell spell = null;

	private bool ondrag = false;
	private Vector3 basePosition;

	// Use this for initialization
	public void Start () {
		if (item != null)
			addItem (item);
		if (spell != null)
			addSpell (spell);
		this.gameObject.SetActive (active);
		print ("MY POS : " + basePosition.x + ", " + basePosition.y + ", " + basePosition.z + ""); 
	}
	
	// Update is called once per frame
	public void Update () {
		if (active != this.gameObject.active)
			this.gameObject.SetActive (active);
		updateIcon ();
	}

	public Item getItem () {
		return (this.item);
	}

	public Spell getSpell() {
		return (this.spell);
	}

	public abstract void addItem (Item item);

	public abstract void removeItem ();

	public abstract void addSpell (Spell spell);

	public abstract void removeSpell ();

	public void updateIcon() {
		if (this.item != null) {
			this.GetComponent<Image> ().sprite = item.icon;
		} else if (this.spell != null) {
			this.GetComponent<Image> ().sprite = spell.icon;
		}
	}

	public void cleanIcon() {
		this.GetComponent<Image> ().sprite = this.blankSprite;
	}

	public int getCaseId() {
		int caseId = -1;
		try
		{
			caseId = Int32.Parse (this.gameObject.name.Substring (4));
		}
		catch (FormatException e)
		{
			Console.WriteLine(e.Message);
		}
		return (caseId);
	}

	public void OnPointerClick(PointerEventData data) {
		isSelected = true;
		int caseId = -1;
		try
		{
			caseId = Int32.Parse (data.selectedObject.name.Substring (4));
		}
		catch (FormatException e)
		{
			Console.WriteLine(e.Message);
		}
		if (caseId == -1)
			return ;
		//Debug.Log("Click On Case Inventory n: " + caseId);
	}

	//Do this when the mouse is clicked over the selectable object this script is attached to.
	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log("Case (" + this.getCaseId() + ") StartDrag.");
		basePosition = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
		//this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y,-1000);
		PointerScript.instance.followCursor (this.gameObject);
	}

	//Do this when the mouse click on this selectable UI object is released.
	public void OnPointerUp(PointerEventData eventData)
	{
		Item item = this.item;
		Spell spell = this.spell;

		PointerScript.instance.unfollowCursor (this.gameObject);
		this.transform.position = new Vector3 (basePosition.x, basePosition.y, this.transform.position.z);

		if (PointerScript.instance.curButton () != null && PointerScript.instance.curButton () != this) {
			AbstractCaseButton newCase = PointerScript.instance.curButton ();

			this.removeItem ();
			this.removeSpell ();
			int button_type = -1;

			if ((newCase is ItemCaseButtonScript)) {
				button_type = 0;
			} if ((newCase is SpellCaseButtonScript)) {
				button_type = 1;
			}
			if (newCase.getItem() != null) {
				this.addItem (newCase.item);
			}
			if (newCase.getSpell() != null) {
				this.addSpell (newCase.spell);
			}
			switch (button_type) {
			case 0:
				if (item != null) {
					newCase.addItem (item);
				}
				break;
			case 1:
				if (spell != null) {
					newCase.addSpell (spell);
				}
				break;
			default:
				if (item != null) {
					newCase.addItem (item);
				}
				else if (spell != null) {
					newCase.addSpell (spell);
				}
				break;
			}
			Debug.Log("Case (" + this.getCaseId() + ") Dropped to Case (" + newCase.name + ")");
		}
		PointerScript.instance.setCurButton (null);
	}

	//Do this when the cursor enters the rect area of this selectable UI object.
	public void OnPointerEnter(PointerEventData eventData)
	{
		PointerScript.instance.setCurButton (this);
	}

	//Do this when the cursor exits the rect area of this selectable UI object.
	public void OnPointerExit(PointerEventData eventData)
	{
		if (PointerScript.instance.curButton () == this) {
			PointerScript.instance.setCurButton (null);
		}
	}
}
