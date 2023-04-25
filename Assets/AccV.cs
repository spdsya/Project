using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AccV : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool accClick = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown (PointerEventData eventData)
    {
        accClick = true;
    }

    public void OnPointerUp (PointerEventData eventData)
    {
        accClick = false;
    }
}
