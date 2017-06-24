﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIBannerScript : MonoBehaviour{

	public ButtonScript[] cases;

	public UICaracteristiquesScript caracteristiquePanel;
	public UISpellsScript spellsPanel;
	public UIInventoryScript inventoryPanel;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void _hookClickEntry() {
		foreach (ButtonScript c in cases) {
			if (c.isSelected) {
				c.isSelected = false;
				OnclickCase (c);
			}
		}
	}

	public void OnOpenUICarac() {
		Debug.Log ("Open Carac");
		caracteristiquePanel.setVisible (!caracteristiquePanel.visible);
	}

	public void OnOpenUIInventory() {
		Debug.Log ("Open Inventory");
		inventoryPanel.setVisible (!inventoryPanel.visible);
	}

	public void OnOpenUISpells() {
		Debug.Log ("Open Spells");
		spellsPanel.setVisible (!spellsPanel.visible);
	}

	public void OnclickCase(ButtonScript button) {
		
	}

}