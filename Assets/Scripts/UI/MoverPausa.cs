using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoverPausa : MonoBehaviour
{
    public Selectable[] elementosUI;
    private int indiceActual = 0;
    private float cooldown = 0.2f;
    private float tiempoUltimoMovimiento = 0f;

    void Start()
    {
        if (elementosUI.Length > 0)
        {
            SeleccionarElemento(indiceActual);
        }
        else
        {
            Debug.LogError("No hay elementos UI asignados.");
        }
    }

    void Update()
    {
        if (Time.time - tiempoUltimoMovimiento < cooldown)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            MoverSeleccion(-1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            MoverSeleccion(1);
        }

        if (EventSystem.current.currentSelectedGameObject == null)
        {
            SeleccionarElemento(indiceActual);
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            AbrirDropdownSiEsNecesario();
        }
    }

    void MoverSeleccion(int direccion)
    {
        if (elementosUI.Length == 0) return;

        int nuevoIndice = indiceActual + direccion;

        if (nuevoIndice < 0) nuevoIndice = elementosUI.Length - 1;
        if (nuevoIndice >= elementosUI.Length) nuevoIndice = 0;

        indiceActual = nuevoIndice;
        SeleccionarElemento(indiceActual);

        tiempoUltimoMovimiento = Time.time;
    }

    void SeleccionarElemento(int indice)
    {
        if (elementosUI.Length == 0) return;
        EventSystem.current.SetSelectedGameObject(elementosUI[indice].gameObject);
    }

    void AbrirDropdownSiEsNecesario()
    {
        GameObject seleccionado = EventSystem.current.currentSelectedGameObject;
        if (seleccionado != null)
        {
            Dropdown dropdown = seleccionado.GetComponent<Dropdown>();
            if (dropdown != null)
            {
                dropdown.Show();
            }
        }
    }
}
