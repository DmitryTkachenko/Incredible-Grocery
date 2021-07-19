using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointScript : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        
        GameBehaviour.current.CompareOrderAndBusket(eventData.pointerEnter);
       
    }
    
}
