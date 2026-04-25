using UnityEngine;
using System.Collections.Generic;
using System.Collections;
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemUpdate : ItemAbstract
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private SphereCollider sCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }


}


   
}
