using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;

public class SpellCaseButtonScript : MonoBehaviour, IPointerClickHandler, IPointerUpHandler, IPointerDownHandler {

	public bool isSelected = false;
	public bool active = true;
	public bool onDrop = false;
	public Sprite blankSprite;

	public Spell spell = null;

	private bool ondrag = false;

	// Use this for initialization
	void Start () {
		if (spell != null)
			addSpell (spell);
		this.gameObject.SetActive (active);
	}

	// Update is called once per frame
	void Update () {
		if (active != this.gameObject.active)
			this.gameObject.SetActive (active);
		if (isSelected == true) {

		}
	}

	public Spell getSpell() {
		return (this.spell);
	}

	public void addSpell(Spell spell) {
		this.spell = spell;
		this.GetComponent<Image> ().sprite = spell.icon;
	}

	public void removeSpell() {
		this.spell = null;
		this.GetComponent<Image> ().sprite = blankSprite;
	}

	public void OnPointerClick(PointerEventData data) {
		isSelected = true;
		int caseId = -1;
		try
		{
			caseId = Int32.Parse (data.selectedObject.name.Substring (9));
		}
		catch (FormatException e)
		{
			Console.WriteLine(e.Message);
		}
		if (caseId == -1)
			return ;
		Debug.Log("Click On Case Spell n: " + caseId);
	}

	public int getCaseId() {
		int caseId = -1;
		try
		{
			caseId = Int32.Parse (this.gameObject.name.Substring (9));
		}
		catch (FormatException e)
		{
			Console.WriteLine(e.Message);
		}
		return (caseId);
	}

	//Do this when the mouse is clicked over the selectable object this script is attached to.
	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log("Case (" + this.getCaseId() + ") StartDrag.");
	}

	//Do this when the mouse click on this selectable UI object is released.
	public void OnPointerUp(PointerEventData eventData)
	{
		Debug.Log("Case (" + this.getCaseId() + ") Dropped ");
	}
}
