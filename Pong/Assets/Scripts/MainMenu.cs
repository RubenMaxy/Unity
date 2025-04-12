using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  
    public void PlayerCPU()
    {
        // Carga la escena de jugar contra la IA
        SceneManager.LoadScene("PlayerCPU");
    }

    public void PVP()
    {
        //Carga la escena de 2 jugadores
        SceneManager.LoadScene("PVP");
    }
}
