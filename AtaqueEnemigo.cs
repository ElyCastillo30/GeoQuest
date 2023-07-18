using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    private void OnTiggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PersonajeMovimiento personaje = collision.gameObject.GetComponent<PersonajeMovimiento>();
            personaje.CausarHerida();
        }
    }
}
