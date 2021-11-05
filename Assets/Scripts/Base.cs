using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
	[SerializeField] private ShipManager shipManager;
	private void OnTriggerEnter(Collider other)
	{
		shipManager.LoseScore(other);
	}
}
