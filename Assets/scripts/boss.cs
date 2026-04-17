using UnityEngine;

public class boss : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float leftBoundary = -8f;
    public float rightBoundary = 8f;

    private int moveDirection = 1;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * moveDirection * moveSpeed * Time.deltaTime);

        if (transform.position.x >= rightBoundary)
        {
            moveDirection = -1;
        }
        else if (transform.position.x <= leftBoundary)
        {
            moveDirection = 1;
        }

        spriteRenderer.flipX = moveDirection == -1;
    }
}
