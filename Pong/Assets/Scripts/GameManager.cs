using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pelota, player1, player2; // Se inicializan en el inspector. Referencias a los objetos que estan en el juego y debe gestionar.
    public int player1Score = 0, player2Score = 0; //Se inicializa en el inspector. Controlan las puntuaciones de cada jugador
    public TMPro.TextMeshProUGUI player1ScoreText, player2ScoreText;

    public void GoalScored(int playerNumber)
    {
        if (playerNumber == 1)
        {
            player1Score++;
            player1ScoreText.text=player1ScoreText.ToString(); //Es un objeto, por eso se debe indicar que se quiere cambiar el texto
        }
        else if (playerNumber == 2)
        {
            player2Score++;
            player1ScoreText.text = player2ScoreText.ToString();
        }
        ResetPositions();
    }

    private void ResetPositions()
    {
        pelota.GetComponent<Ball>().Reset();
        player1.GetComponent<Player>().Reset();
        player2.GetComponent<Player>().Reset();
    }
}
