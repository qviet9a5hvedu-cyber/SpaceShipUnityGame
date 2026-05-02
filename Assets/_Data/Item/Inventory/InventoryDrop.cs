using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDrop : InventoryAbstract
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(Test), 1);
    }

    protected virtual void Test()
    {
        this.DropItemIndex(0);
    }

    protected virtual bool DropItemIndex(int index)
    {
        return true;
    }






}
