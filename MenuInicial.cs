using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    private Sonidos sound;
    
    void Update()
    {
        sound = FindObjectOfType<Sonidos>();
    }

    public void Jugar()
    {
        sound.SeleccionAudio(0, 0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        sound.SeleccionAudio(1, 0.5f);
        Application.Quit();
    }

}
