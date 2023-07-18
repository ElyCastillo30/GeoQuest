using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum Respuestas
{
    Correcta,
    Correcta2,
    Correcta3,
    Incorrecta
}

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Respuestas resultados;
    public DialogoNFC dialogonfc;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(message: "OnDrop");
        GameObject dropped = eventData.pointerDrag;
        DragHandler draggableItem = dropped.GetComponent<DragHandler>();

        if (resultados == draggableItem.resultados)
        {
            Destroy(draggableItem.gameObject);
            dialogonfc.SumarPuntaje();
            dialogonfc.panelGanaste.SetActive(true);
        }
        else
        {
            dialogonfc.panelRetro.SetActive(true);
        }

        
    }
}
