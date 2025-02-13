using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        this.LoadComponent();
    }

    protected virtual void Reset()
    {
        this.LoadComponent();
    }

    protected virtual void LoadComponent()
    {
        
    }
}
