using UnityEngine;
using TMPro;

public class RankingUI : MonoBehaviour
{
    public TMP_Text rankingTexto;

    void Start()
    {
        MostrarRanking();
    }

    void MostrarRanking()
    {
        Ranking ranking = Ranking.Cargar();
        //rankingTexto.text = "Mejores Tiempos:\n";
        int puesto = 1;
        foreach (var entrada in ranking.entradas)
        {
            int min = Mathf.FloorToInt(entrada.tiempo / 60);
            int seg = Mathf.FloorToInt(entrada.tiempo % 60);
            rankingTexto.text += $"{puesto}. {entrada.nombre} - {min:00}:{seg:00}\n";
            puesto++;
        }

    }
}
