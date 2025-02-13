using System.Collections;
using UnityEngine;

public class PlayerMovement : PlayerAbstract
{
    [Header("Player Movement")]
    [SerializeField] protected Vector2 targetPos;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] protected bool isMoving = false;
    [SerializeField] protected float speed = 5f;
    public bool IsMoving => isMoving;
    protected override void Start()
    {
        base.Start();
        this.targetPos = this.transform.parent.position;
    }
    protected void Update()
    {
        this.Moving();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPointsToStop();
    }
    protected void LoadPointsToStop()
    {
        if (this.pointA != null && this.pointB != null) return;
        this.pointA = GameObject.Find("PointA").transform;
        this.pointB = GameObject.Find("PointB").transform;
        Debug.Log(transform.name + ": LoadPointsToStop");
    }
    protected void Moving()
    {
        float horizontal = InputManager.Instance.Horizontal;

        if (isMoving) return;
        if (horizontal == 0) return;
        if (this.IsAtBoundary(horizontal)) return;

        this.FlippingDirect(horizontal);
        this.targetPos = new Vector2(this.targetPos.x + horizontal, this.targetPos.y);

        StartCoroutine(MoveToTarget());
    }
    protected bool IsAtBoundary(float horizontal)
    {
        Vector2 pointAPos = this.pointA.position;
        Vector2 pointBPos = this.pointB.position;
        Vector2 playerPos = this.transform.parent.position;
        bool conditionA = pointAPos.x == playerPos.x && horizontal < 0;
        bool conditionB = pointBPos.x == playerPos.x && horizontal > 0;
        if (conditionA || conditionB) return true;
        return false;
    }
    protected void FlippingDirect(float horizontal)
    {
        if (horizontal < 0) this.transform.parent.localScale = new Vector3(-1, 1, 1);
        else this.transform.parent.localScale = Vector3.one;
    }

    private IEnumerator MoveToTarget()
    {
        this.isMoving = true;
        while ((Vector2)this.transform.parent.position != this.targetPos)
        {
            this.transform.parent.position = Vector2.MoveTowards(this.transform.parent.position, this.targetPos,
             this.speed * Time.deltaTime);
            yield return null;
        }
        this.isMoving = false;
    }
}
