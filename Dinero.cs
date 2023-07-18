using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinero : MonoBehaviour
{
    public delegate void SumaDinero(int dinero);
    public static event SumaDinero sumaDinero;

    [SerializeField] private int cantidadDinero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (sumaDinero != null)
            {
                SumarDinero();
                Destroy(this.gameObject);
            }
        }
    }

    private void SumarDinero()
    {
        sumaDinero(cantidadDinero);
    }
}

