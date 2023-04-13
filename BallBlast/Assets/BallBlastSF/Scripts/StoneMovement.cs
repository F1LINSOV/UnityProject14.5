using UnityEngine;
using System;

public class StoneMovement : MonoBehaviour
{
    [SerializeField] private float gravity;
    [SerializeField] private float reboundSpeed;
    [SerializeField] private float harizontalSpeed;
    [SerializeField] private float gravityOffset;
    [SerializeField] private float rotationSpeed;

    private bool UseGravity;

    private Vector3 velocity;

    private void Awake()
    {
        velocity.x = -Mathf.Sign(transform.position.x) * harizontalSpeed;
    }

    private void Update()
    {
        TruEnableGravity();
        Move();
    }

    private void TruEnableGravity()
    {
        if (Math.Abs(transform.position.x) <= Math.Abs(LevelBoundary.Instance.LeftBorder) - gravityOffset)
        {
            UseGravity = true;
        }
    }

    private void Move()
    {
        if (UseGravity == true)
        {
            velocity.y -= gravity * Time.deltaTime;

            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }

        velocity.x = Mathf.Sign(velocity.x) * harizontalSpeed;

        transform.position += velocity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelEdge levelEdge = collision.GetComponent<LevelEdge>();

        if (levelEdge != null)
        {
            if (levelEdge.Type == EdgeType.Bottom)
            {
                velocity.y = reboundSpeed;
            }
            if (levelEdge.Type == EdgeType.Left && velocity.x < 0 || levelEdge.Type == EdgeType.Right && velocity.x > 0)
            {
                velocity.x *= -1;
            }
        }
    }

    public void AddVerticalVelocity(float velocity)
    {
        this.velocity.y += velocity;
    }

    public void SetHorizontalDirection(float direction)
    {
        velocity.x = Mathf.Sign(direction) * harizontalSpeed;
    }
}
