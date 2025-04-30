using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerScene : MonoBehaviour
{
    private GameManager gameManager;
    public TMPro.TextMeshProUGUI winnerText;

    public void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        winnerText.text += gameManager.GetComponent<GameManager>().getGanador();
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
