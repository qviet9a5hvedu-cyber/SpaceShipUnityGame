using UnityEngine;

public abstract class ItemAbstract : Automation
{
    [SerializeField] protected Inventory _inventory;
    public Inventory inventory => _inventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }
    protected virtual void LoadInventory()
    {
        if (_inventory != null) return;
        _inventory = transform.parent.GetComponentInParent<Inventory>();
    }
}
