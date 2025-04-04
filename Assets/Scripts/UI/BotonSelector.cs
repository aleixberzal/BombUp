using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BotonSelector : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public Image fondoBoton;

    public void OnSelect(BaseEventData eventData)
    {
        // Cambia el color al ser seleccionado
        fondoBoton.color = Color.yellow;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        // Vuelve al color original cuando se deselecciona
        fondoBoton.color = Color.white;
    }
}
