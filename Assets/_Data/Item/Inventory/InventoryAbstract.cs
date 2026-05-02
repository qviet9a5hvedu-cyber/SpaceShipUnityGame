using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryAbstract : Automation
{
	[Header("Junk Abstract")]
	[SerializeField] protected Inventory _inventory;
	public Inventory inventory => _inventory;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadInventory();
	}

	protected virtual void LoadInventory()
	{
		if (this._inventory != null) return;
		this._inventory = transform.parent.GetComponent<Inventory>();
		Debug.Log(transform.name + ": LoadInventory", gameObject);
	}
}
