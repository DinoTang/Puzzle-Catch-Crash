using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbstract : DinoMonoBehaviour
{
    [Header("Player Abstract")]
    [SerializeField] protected PlayerCtrl playerCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }

    protected void LoadPlayerCtrl()
    {
        if(this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl");
    }

}
