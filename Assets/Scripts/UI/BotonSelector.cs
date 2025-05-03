using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BotonSelector : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public Image fondoBoton; // Imagen del fondo del bot�n
    private Color originalColor; // Color original del fondo

    void Awake()
    {
        // Aseg�rate de que siempre tengas la referencia
        if (fondoBoton == null)
            fondoBoton = GetComponent<Image>();
    }

    void OnEnable()
    {
        // Si no tenemos una referencia a la imagen, la obtenemos al activarse
        if (fondoBoton == null)
            fondoBoton = GetComponent<Image>();

        // Guardamos el color original al activarse
        originalColor = fondoBoton.color;

        // Si el bot�n no est� seleccionado, llamamos a OnDeselect para restaurar su color original
        if (EventSystem.current.currentSelectedGameObject != this.gameObject)
        {
            OnDeselect(null);
        }

        // Forzamos la selecci�n del bot�n al activarse
        EventSystem.current.SetSelectedGameObject(this.gameObject);
    }

    // Cuando el bot�n es seleccionado, cambiamos la opacidad a 1 (totalmente visible)
    public void OnSelect(BaseEventData eventData)
    {
        SetAlpha(1f);
    }

    // Cuando el bot�n es deseleccionado, restauramos el color original
    public void OnDeselect(BaseEventData eventData)
    {
        SetAlpha(originalColor.a);
    }

    // M�todo para cambiar la opacidad del color del fondo
    void SetAlpha(float alpha)
    {
        Color newColor = fondoBoton.color;
        newColor.a = alpha; // Establece el valor de alpha (transparencia)
        fondoBoton.color = newColor; // Asigna el nuevo color con el alpha modificado
    }

    void OnDisable()
    {
        // Asegura que cuando el bot�n se desactive, no se quede con alpha = 1
        SetAlpha(originalColor.a);
    }
}
