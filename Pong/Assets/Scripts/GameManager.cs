using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pelota, player1, player2; // Se inicializan en el inspector. Referencias a los objetos que estan en el juego y debe gestionar.
    public int player1Score = 0, player2Score = 0; //Se inicializa en el inspector. Controlan las puntuaciones de cada jugador
    public TMPro.TextMeshProUGUI player1ScoreText, player2ScoreText;
    public bool pvp;

    public int maxScore = 5;
    private string ganador; // Se usa para saber quien gana la partida
    private static GameManager _instance; //Para comprobar que es un singleton

    //Se ejecuta antes de todo lo demas, comprueba si ya existe un GameManager, si no existe lo inicializa y lo añade a DontDestroyOnLoad
    private void Awake()
    {
        if (_instance != null && _instance !=this)
        {
            Destroy(_instance.gameObject);
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

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
            player2ScoreText.text = player2Score.ToString();
        }
        checkWinner();
        ResetPositions();
    }

    private void checkWinner()
    {
        if(player1Score>= maxScore)
        {
            Debug.Log("Player 1 wins");
            ganador = "Player 1";
        }
        else if (player2Score >= maxScore && pvp)
        {
            Debug.Log("Player 2 wins");
            ganador = "Player 2";
        }
        else if(player2Score >= maxScore && !pvp)
        {
            Debug.Log("CPU wins");
            ganador = "CPU";
        }

        if(player1Score >= maxScore || player2Score>= maxScore)
        {
            SceneManager.LoadScene("WinnerScene");
        }
    }

    public string getGanador()
    {
        return ganador;
    }

    private void ResetPositions()
    {
        pelota.GetComponent<Ball>().Reset();
        player1.GetComponent<Player>().Reset();
        if (pvp) {
            player2.GetComponent<Player>().Reset(); 
        } 
    }

}
