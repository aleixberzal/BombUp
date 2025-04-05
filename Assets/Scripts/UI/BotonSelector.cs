using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BotonSelector : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public Image fondoBoton;
    private Color originalColor;


    public void Start()
    {
        fondoBoton = GetComponent<Image>();
        originalColor = fondoBoton.color;
    }
    public void OnSelect(BaseEventData eventData)
    {
        SetAlpha(1f);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        SetAlpha(originalColor.a);
    }

    void SetAlpha(float alpha)
    {
        Color newColor = fondoBoton.color;
        newColor.a = alpha;
        fondoBoton.color = newColor;
    }
}
