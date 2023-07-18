using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoNFC : MonoBehaviour
{
    public PersonajeMovimiento jugador;
    public GameObject panelRetro;
    public GameObject panelNPC2;
    public GameObject panelGanaste;
    public GameObject panelPresentacion;
    public TextMeshProUGUI textoPregunta;
    public bool respuestaCorrecta;
    public bool respuestaIncorrecta;
    public delegate void SumaPuntaje(int puntos);
    public static event SumaPuntaje sumaPuntaje;
    [SerializeField] private int cantidadPuntaje;
    [SerializeField] private GameObject MarketDialog;
    private bool isButtonInsideTrigger = false;

    public Toggle Verdadero, Falso;
    public Button dialogoButon, botonConfirmar;

    void Start()
    {
        Verdadero.onValueChanged.AddListener((isSelected) =>
        {
            if(isSelected)
            {
                panelGanaste.SetActive(true);
                SumarPuntaje();
            }
        });

        Falso.onValueChanged.AddListener((isSelected) =>
        {
            if (isSelected)
            {
                panelRetro.SetActive(true);
            }
        });
    }

    void Update()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<PersonajeMovimiento>();

    }

    public void MiBotonClick()
    {
        if(isButtonInsideTrigger)
        {
            panelNPC2.SetActive(true);
        }
    }

    public void BotonPresentacion()
    {
        if(isButtonInsideTrigger)
        {
            panelPresentacion.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == dialogoButon.gameObject)
        {
            isButtonInsideTrigger = true;
            MarketDialog.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == dialogoButon.gameObject)
        {
            MarketDialog.SetActive(false);
            isButtonInsideTrigger = false;
            Time.timeScale = 1f;
        }
    }

    public void RespuestaIncorrecta()
    {
        jugador.enabled = true;
        respuestaIncorrecta = true;
        panelNPC2.SetActive(false);
        panelRetro.SetActive(true);
    }

    public void RespuestaCorrecta()
    {
        if(respuestaCorrecta == false)
        {
            jugador.enabled = true;
            SumarPuntaje();
        }
        panelNPC2.SetActive(false);
        panelGanaste.SetActive(true);
    }

    public void ButtonOk ()
    {
        if(botonConfirmar == true)
        {
            panelRetro.SetActive(false);
            panelGanaste.SetActive(false);
            panelNPC2.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void SumarPuntaje()
    {
        sumaPuntaje(cantidadPuntaje);
    }
}
