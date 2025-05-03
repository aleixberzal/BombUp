using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BotonSelector : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public Image fondoBoton; // Imagen del fondo del botón
    private Color originalColor; // Color original del fondo

    void Awake()
    {
        // Asegúrate de que siempre tengas la referencia
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

        // Si el botón no está seleccionado, llamamos a OnDeselect para restaurar su color original
        if (EventSystem.current.currentSelectedGameObject != this.gameObject)
        {
            OnDeselect(null);
        }

        // Forzamos la selección del botón al activarse
        EventSystem.current.SetSelectedGameObject(this.gameObject);
    }

    // Cuando el botón es seleccionado, cambiamos la opacidad a 1 (totalmente visible)
    public void OnSelect(BaseEventData eventData)
    {
        SetAlpha(1f);
    }

    // Cuando el botón es deseleccionado, restauramos el color original
    public void OnDeselect(BaseEventData eventData)
    {
        SetAlpha(originalColor.a);
    }

    // Método para cambiar la opacidad del color del fondo
    void SetAlpha(float alpha)
    {
        Color newColor = fondoBoton.color;
        newColor.a = alpha; // Establece el valor de alpha (transparencia)
        fondoBoton.color = newColor; // Asigna el nuevo color con el alpha modificado
    }

    void OnDisable()
    {
        // Asegura que cuando el botón se desactive, no se quede con alpha = 1
        SetAlpha(originalColor.a);
    }
}
