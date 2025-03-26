using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayer1Goal; //Se inicializa en el inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (isPlayer1Goal)
            {
                FindFirstObjectByType<GameManager>().GoalScored(1);
            }
            else
            {
                FindFirstObjectByType<GameManager>().GoalScored(2);
            }
        }
    }
}
