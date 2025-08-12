using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        float dirX = Random.value < 0.5f ? -1 : 1;
        float dirY = Random.Range(-0.5f, 0.5f);
        Vector2 direction = new Vector2(dirX, dirY).normalized;
        rb.linearVelocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Down"))
        {
            // Ball went through the left/red side – Blue scores
            GameManager.Instance.AddScoreToBlue();
            ResetBall();
        }
        else if (collider.gameObject.CompareTag("Top"))
        {
            // Ball went through the right/blue side – Red scores
            GameManager.Instance.AddScoreToRed();
            ResetBall();
        }
    }

    public void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector3.zero;
        Invoke(nameof(LaunchBall), 1f);
    }
}