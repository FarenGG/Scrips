using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class MenuPrincipal : MonoBehaviour
{
    private void Start()
    {
        // IMPORTANTE: Al entrar al menú, liberamos el mouse para poder hacer clic
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Jugar()
    {
        // Carga la escena siguiente (el índice 1 en la lista)
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}