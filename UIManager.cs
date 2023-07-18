using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int totalDinero;
    private int totalPuntaje;
    [SerializeField] private TMP_Text textoPuntaje;
    [SerializeField] private TMP_Text textoDinero;
    [SerializeField] private List<GameObject> listaCorazones;
    [SerializeField] private Sprite corazonDesactivado;

    private void Start()
    {
        Dinero.sumaDinero += SumarDinero;
        DialogoNFC.sumaPuntaje += SumarPuntaje;
    }

    private void SumarDinero(int dinero)
    {
        totalDinero += dinero;
        textoDinero.text = totalDinero.ToString();
    }
    private void SumarPuntaje(int puntos)
    {
        totalPuntaje += puntos;
        textoPuntaje.text = totalPuntaje.ToString();
    }

    public void RestarCorazones(int indice)
    {
        Image imagenCorazon = listaCorazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazonDesactivado;
    }
}
