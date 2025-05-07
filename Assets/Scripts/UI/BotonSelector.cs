using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BotonSelector : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public Image fondoBoton;
    private Color originalColor;

    public RectTransform imagenIndicadora;
    public RectTransform imagenIndicadora2;
    private RectTransform miRectransform;

    void Awake()
    {
        if (fondoBoton == null)
            fondoBoton = GetComponent<Image>();

        miRectransform = GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        if (fondoBoton == null)
            fondoBoton = GetComponent<Image>();

        originalColor = fondoBoton.color;

        if (EventSystem.current.currentSelectedGameObject != this.gameObject)
        {
            OnDeselect(null);
        }

        EventSystem.current.SetSelectedGameObject(this.gameObject);
    }

    public void OnSelect(BaseEventData eventData)
    {
        SetAlpha(1f);

        if (imagenIndicadora != null)
        {
            Vector2 nuevaPos = imagenIndicadora.anchoredPosition;
            nuevaPos.y = miRectransform.anchoredPosition.y;
            imagenIndicadora.anchoredPosition = nuevaPos;

            imagenIndicadora.gameObject.SetActive(true);
        }

        if (imagenIndicadora2 != null)
        {
            Vector2 nuevaPos = imagenIndicadora2.anchoredPosition;
            nuevaPos.y = miRectransform.anchoredPosition.y;
            imagenIndicadora2.anchoredPosition = nuevaPos;

            imagenIndicadora2.gameObject.SetActive(true);
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        SetAlpha(originalColor.a);

        if (imagenIndicadora != null)
        {
            imagenIndicadora.gameObject.SetActive(false);
        }
        if (imagenIndicadora2 != null)
        {
            imagenIndicadora2.gameObject.SetActive(false);
        }
    }

    void SetAlpha(float alpha)
    {
        Color newColor = fondoBoton.color;
        newColor.a = alpha;
        fondoBoton.color = newColor;
    }

    void OnDisable()
    {
        SetAlpha(originalColor.a);
    }
}
