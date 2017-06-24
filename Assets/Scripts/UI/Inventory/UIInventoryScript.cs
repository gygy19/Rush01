using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryScript : MonoBehaviour {

	public ButtonScript exitButton;
	public GameObject[] contentObjects;
	public bool visible = false;

	public ItemCaseButtonScript[] cases;
	public ItemCaseButtonScript infosCase;
	public Text lblInfos;


	public static string LBL_EMPTY_SELECTION = "None selected object.";

	// Use this for initialization
	void Start () {
		foreach (GameObject o in contentObjects) {
			o.SetActive (false);
		}
		lblInfos.text = LBL_EMPTY_SELECTION;
		//infosCase.//clean Image
	}
	
	// Update is called once per frame
	void Update () {
		if (exitButton.isSelected) {
			exitButton.isSelected = false;
			setVisible (false);
		}
		_checkOnClickCase ();
	}

	private void _checkOnClickCase() {
		foreach (ItemCaseButtonScript c in cases) {
			if (c.isSelected) {

				Debug.Log("Click On Case Inventory n: " + c.getCaseId());
				/*if (c.item == null) {
					//infosCase.//clean Image
					lblInfos.text = "";//clean text
				}*/
				c.isSelected = false;
			}
		}
	}

	public void setVisible(bool visible) {
		this.visible = visible;
		foreach (GameObject o in contentObjects) {
			o.SetActive (visible);
		}
	}

	public void addItems() {
		//TODO
	}

	public void addItem() {
		//TODO
	}

	public void removeItem() {
		//TODO
	}
}
