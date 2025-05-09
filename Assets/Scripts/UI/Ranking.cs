using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EntradaRanking
{
    public string nombre;
    public float tiempo;

    public EntradaRanking(string nombre, float tiempo)
    {
        this.nombre = nombre;
        this.tiempo = tiempo;
    }
}

[System.Serializable]
public class Ranking
{
    public List<EntradaRanking> entradas = new List<EntradaRanking>();

    public void AgregarTiempo(string nombre, float nuevoTiempo)
    {
        entradas.Add(new EntradaRanking(nombre, nuevoTiempo));
        entradas.Sort((a, b) => a.tiempo.CompareTo(b.tiempo));
        if (entradas.Count > 5)
        {
            entradas.RemoveAt(entradas.Count - 1);
        }
    }

    public void Guardar()
    {
        string json = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("RankingTiempos", json);
        PlayerPrefs.Save();
    }

    public static Ranking Cargar()
    {
        if (PlayerPrefs.HasKey("RankingTiempos"))
        {
            string json = PlayerPrefs.GetString("RankingTiempos");
            return JsonUtility.FromJson<Ranking>(json);
        }
        return new Ranking();
    }
}

