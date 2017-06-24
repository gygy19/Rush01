using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;

public class ItemCaseButtonScript : MonoBehaviour, IPointerClickHandler, IPointerUpHandler, IPointerDownHandler {
	
	public bool isSelected = false;
	public bool active = true;
	public bool onDrop = false;
	public Sprite blankSprite;

	public Item item = null;
	//ITEM

	private bool ondrag = false;

	// Use this for initialization
	void Start () {
		if (item != null)
			addItem (item);
		this.gameObject.SetActive (active);
	}

	// Update is called once per frame
	void Update () {
		if (active != this.gameObject.active)
			this.gameObject.SetActive (active);
		if (isSelected == true) {
			
		}
	}

	public Item getItem() {
		return (this.item);
	}

	public void addItem(Item item) {
		this.item = item;
		this.GetComponent<Image> ().sprite = item.icon;
	}

	public void removeItem() {
		this.item = null;
		this.GetComponent<Image> ().sprite = blankSprite;
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
