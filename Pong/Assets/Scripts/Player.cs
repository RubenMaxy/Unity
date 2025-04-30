using UnityEngine;

public class Player : MonoBehaviour
{
    public bool player1; //Se inicia en el inspector
    public float speed = 20f; //Velocidad de movimiento, se modificará en el inspector
    public Rigidbody2D rb; //Se inicia en el inspector

    private float movement = 0f; //Se inicia en el inspector
    private Vector2 startPos; //Posicion inicial

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1)
        {
            movement = Input.GetAxisRaw("Vertical2");
        } else
        {
            movement = Input.GetAxisRaw("Vertical");
        }
        rb.linearVelocityY = movement * speed * Time.deltaTime;
    }

    public void Reset()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = startPos;
    }
}
