using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 300f; // Se inicia en el inspector
    public Rigidbody2D rb; // Se inicia en el inspector
    public float speedIncrease = 0.1f;

    private Vector2 startPos; // Se inicia en el inspector

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        Launch();
    }

    public void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1; // Ramdon para obtener un 1 o -1
        float y = Random.Range(0, 2) == 0 ? -1 : 1; // Ramdon para obtener un 1 o -1
        rb.linearVelocity = new Vector2(speed * x * Time.deltaTime, speed * y * Time.deltaTime);
    }

    public void Reset()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = startPos;
        Launch();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.linearVelocity *= 1 + speedIncrease;
        }
    }
}
