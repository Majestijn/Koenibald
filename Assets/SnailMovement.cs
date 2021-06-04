using UnityEngine;

public class SnailMovement : MonoBehaviour
{
    [SerializeField] private Transform fromPos, toPos;
    private Vector3 currentDir;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentDir = fromPos.position;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(rb.position, currentDir) > 1f)
        {
            Vector3 dir = (currentDir - new Vector3(rb.position.x, rb.position.y, 0)).normalized;
            rb.MovePosition(new Vector3(rb.position.x, rb.position.y, 0) + dir * (moveSpeed * Time.fixedDeltaTime));
        }
        else
            SwitchDirection();
    }

    private void SwitchDirection()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;

        if (currentDir == fromPos.position)
            currentDir = toPos.position;
        else
            currentDir = fromPos.position;
    }
}