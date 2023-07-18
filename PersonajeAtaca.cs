using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeAtaca : MonoBehaviour
{
    private BoxCollider2D colEspada;

    private void Awake()
    {
        colEspada = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if(otro.CompareTag("Enemigo"))
        {
            Destroy (otro.gameObject);
        }
    }
}
