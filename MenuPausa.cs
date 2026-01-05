using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuPausa : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject panelPausaUI; 
    public ControladorTerceraPersona jugador; 

    private bool juegoPausado = false;

    // --- NUEVO: ESTO ARREGLA TU PROBLEMA ---
    private void Start()
    {
        // Aseguramos que al entrar al nivel el menú esté cerrado y el juego corriendo
        Reanudar();
    }
    // ---------------------------------------

    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (juegoPausado) Reanudar();
            else Pausar();
        }

        if (Keyboard.current.f11Key.wasPressedThisFrame)
        {
            LiberarMouseEmergencia();
        }
    }

    public void Reanudar()
    {
        panelPausaUI.SetActive(false); // Cierra el menú visualmente
        Time.timeScale = 1f; 
        juegoPausado = false;

        if (jugador != null) jugador.BloquearControles(false); 
    }

    void Pausar()
    {
        panelPausaUI.SetActive(true); // Abre el menú
        Time.timeScale = 0f; 
        juegoPausado = true;

        if (jugador != null) jugador.BloquearControles(true); 
    }

    void LiberarMouseEmergencia()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SalirAlMenuPrincipal()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(0); 
    }
}