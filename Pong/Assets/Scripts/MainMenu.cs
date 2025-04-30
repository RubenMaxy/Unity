using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("ESC para salir");
        }
    }

    public void PlayerCPU()
    {
        //Carga la escena de jugar contra la IA
        SceneManager.LoadScene("PlayerCPU");
    }

    public void PVP()
    {
        //Carga la escena de jugar 2 jugadores
        SceneManager.LoadScene("PVP");
    }
}
