using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HighscoreScript : MonoBehaviour
{
    public Text textoPuntos;
    public Text textoHigscore;
    private int puntos;
    private int highscoreRecord;

    private void Awake()
    {
        LoadFromJson();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //intento pescar pez
        if (other.CompareTag("pez"))
        {
            //si atrapo un pez sumo punto y lo muestro
            puntos++;
            textoPuntos.text = puntos.ToString();

            //actualizo highscore si los puntos superiores al highscore anterior
            if (puntos > highscoreRecord)
            {
                highscoreRecord = puntos;
                textoHigscore.text = highscoreRecord.ToString();

                //Idealmente no estar guardando el json en cada colision. Podria ser cuando se termine el juego
                SaveToJson();
            }
        }
    }

    public void SaveToJson()
    {
        HighscoreDATA data = new HighscoreDATA();
        data.Highscore = highscoreRecord.ToString();
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/HighscoreDATAfile.json", json);
    }

    public void LoadFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/HighscoreDATAfile.json");
        HighscoreDATA data = JsonUtility.FromJson<HighscoreDATA>(json);

        //Actualizamos con la data storeada
        highscoreRecord = int.Parse(data.Highscore);
        textoHigscore.text = data.Highscore;
    }
}
