using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    public GameObject pelota, player1, player2; // Se inicializan en el inspector. Referencias a los objetos que estan en el juego y debe gestionar.
    public int player1Score = 0, player2Score = 0; //Se inicializa en el inspector. Controlan las puntuaciones de cada jugador
    public TMPro.TextMeshProUGUI player1ScoreText, player2ScoreText;  //Hace referencia al texto en si de la puntuación.
    public bool pvp;

    //Método llamado cada vez que se marca un gol
    public void GoalScored(int playerNumber)
    {
        if (playerNumber == 1)
        {
            player1Score++;
            player1ScoreText.text=player1Score.ToString(); //Es un objeto, por eso se debe indicar que se quiere cambiar el texto
        }
        else if (playerNumber == 2)
        {
            player2Score++;
            player1ScoreText.text = player2Score.ToString();
        }
        ResetPositions();
    }

    //Resetea las posiciones de las 2 palas si estamos en PVP y la IZQ si jugamos contra la IA
    private void ResetPositions()
    {
        pelota.GetComponent<Ball>().Reset();
        player1.GetComponent<Player>().Reset();
        if (pvp)
        {
            player2.GetComponent<Player>().Reset();
        }
    }
}
