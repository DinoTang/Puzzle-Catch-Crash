using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : PlayerAbstract
{
    [Header("Player Anim")]
    [SerializeField] protected Animator anim;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnim();
    }

    protected void LoadAnim()
    {
        if (this.anim != null) return;
        this.anim = this.transform.parent.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnim");
    }

    protected void Update()
    {
        this.AnimMoving();
    }

    protected void AnimMoving()
    {
        this.anim.SetBool("isMoving", this.playerCtrl.PlayerMovement.IsMoving);
    }
}
