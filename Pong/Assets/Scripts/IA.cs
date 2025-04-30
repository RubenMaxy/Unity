using UnityEngine;

public class IA : MonoBehaviour
{
    [SerializeField] private float speed = 5f; //Velocidad de movimiento, se modificará en el inspector
    public GameObject ball;


    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {

        if (transform.position.y > ball.transform.position.y)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            //Tambien podriamos: transform.position += new Vector3(0,-speed* Time.deltaTime,0);
        } else if (transform.position.y < ball.transform.position.y)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
}
