using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants {

	public static Vector3 GetMousePosition()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] hits = Physics.RaycastAll (ray);
		foreach (RaycastHit hitInfo in hits)
		{
			if (hitInfo.collider.gameObject.name == "Cemetery")
				return (hitInfo.point); 
		}
		return Vector3.zero;
	}

}
