using UnityEngine;

public class IA : MonoBehaviour
{
    /*
    * Esta propiedad hace que una variable privada la podamos modificar desde el inspector
    */
    [SerializeField] private float speed = 0.1f;
    public GameObject ball;

    void Update()
    {
        Movement();
    }

    //Movimiento de la pala en base a la posici�n de la bola.
    public void Movement()
    {
        if (transform.position.y > ball.transform.position.y) // Si la posici�n de la IA es mayor que la de la pelota, se mueve hacia abajo
        {
            //Creo que el Vector era un Vector2 pero tenia el mismo error, por eso lo cambi� a Vector 3 por si pudiese ser la soluci�n.
            transform.Translate(Vector3.down * speed); //Tambien podriamos: transform.position += 

        } else if (transform.position.y < ball.transform.position.y) // Si la posici�n de la IA es menor que la de la pelota, se mueve hacia arriba
        {
            transform.Translate(Vector3.up * speed);
        }
    }
}
