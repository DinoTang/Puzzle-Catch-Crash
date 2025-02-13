using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : DinoMonoBehaviour
{
    protected static InputManager instance;
    public static InputManager Instance => instance;
    [SerializeField] protected float horizontal;
    public float Horizontal => horizontal;
    protected override void Awake()
    {
        if (InputManager.instance != null) Debug.LogWarning("Only 1 InputManager allows to exist");
        instance = this;
    }
    public void Update()
    {
        this.HorizontalInput();
    }
    protected void HorizontalInput()
    {
        this.horizontal = Input.GetAxisRaw("Horizontal");
    }
    public bool IsCatchPressed()
    {
        return Input.GetKeyDown(KeyCode.UpArrow);
    }
}
