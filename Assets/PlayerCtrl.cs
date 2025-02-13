using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : DinoMonoBehaviour
{
    [SerializeField] protected PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement => playerMovement;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerMovement();
    }
    protected void LoadPlayerMovement()
    {
        if (this.playerMovement != null) return;
        this.playerMovement = GetComponentInChildren<PlayerMovement>();
        Debug.Log(transform.name + ": LoadPlayerMovement");
    }
}
