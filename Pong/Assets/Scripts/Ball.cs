using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 300f; // Se inicia en el inspector
    public Rigidbody2D rb; // Se inicia en el inspector

    private Vector2 startPos; // Se inicia en el inspector

    public float speedIncrease = 0.1f;  //Para aumentar la velocidad

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
    //Cada vez que colisiona aumenta la velocidad. Solo cuando colisiona con las palas tagueadas como player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.linearVelocity *= 1 + speedIncrease;
            // VelocityFix(); Soluciona un posible rebote horizontal eterno
        }
        VelocityFix(); //Soluciona un posible rebote horizontal o vertical eterno
    }

    private void VelocityFix()
    {
        float velocidadDelta = 0.5f; // Velocidad que queremos que aumente la bola
        float velocidadMinima = 0.2f; // Velocidad mínima que queremos que tenga la bola

        if (Mathf.Abs(rb.linearVelocityX) < velocidadMinima) // Si la velocidad de la bola en el eje x es menor que la mínima
        {
            velocidadDelta = Random.value < 0.5f ? velocidadDelta : -velocidadDelta; // Elegimos un valor aleatorio entre -0.5 y 0.5
            rb.linearVelocity = new Vector2(rb.linearVelocityX + velocidadDelta, rb.linearVelocityY); // Aumentamos la velocidad de la bola
        }

        if (Mathf.Abs(rb.linearVelocityY) < velocidadMinima) // Si la velocidad de la bola en el eje y es menor que la mínima
        {
            velocidadDelta = Random.value < 0.5f ? velocidadDelta : -velocidadDelta; // Elegimos un valor aleatorio entre -0.5 y 0.5
            // Otra forma de aumentar la velocidad (esta vez en el eje y)
            rb.linearVelocity += new Vector2(0f, velocidadDelta); // Aumentamos la velocidad de la bola
        }
    }
}
