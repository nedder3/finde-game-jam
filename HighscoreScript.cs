using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreScript : MonoBehaviour
{
    public Text textoPuntos;
    public Text textoHigscore;
   private int puntos =0 ;
   private int highscoreRecord=4;


     private void Awake() {
        textoHigscore.text=highscoreRecord.ToString();
    }

   private void OnTriggerEnter2D(Collider2D other) 
    {
        

            //intento pescar pez

        if(other.CompareTag("pez"))
        {
            //si atrapo un pez sumo punto
            Debug.Log(puntos++);
            
            
            //incremento higscore
            

            textoPuntos.text=puntos.ToString();
            textoHigscore.text=highscoreRecord.ToString();
            
            //actualizo highscore
            if(puntos>=highscoreRecord)
            {
                highscoreRecord=puntos;
                highscoreRecord++;

            }
        }

        
    }
    
    
}
