using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    //public instance
    public static int level;
    public bool IsStart=false;
    public static int nbEnn;
    public GameObject UiGameOver;

    //public instance audio
    public AudioSource GameOverFx;
    public AudioSource Ambiance1;
    public AudioSource Ambiance2;

    public GameObject spawn;

    //instance child
    float waveTimer = 20f;
    bool IsRoundActive = false;
    bool TimerActive = true;
    public static int nbEnnWave;
    // Start is called before the first frame update
    void Start()
    {
        //début de jeu
        level = 0;
        spawn.SetActive(false);
        Ambiance2.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerActive)
        {
            if (waveTimer > 0)
            {
                waveTimer -= Time.deltaTime;
            }
            if (waveTimer < 0)
            {
                //quand la nouvelle vage commence
                level++;
                IsRoundActive = true;
                nbEnnWave = 10 + level * 4;
                TimerActive = false;
                Ambiance2.Stop();
                Ambiance1.Play();
            }
        }

        if(IsRoundActive)
        {
            spawn.SetActive(true);
            Debug.Log(nbEnnWave);
            if (nbEnnWave<=0)
            {
                //quand la vague fini
                spawn.SetActive(false);
                IsRoundActive = false;
                waveTimer = 15f;
                TimerActive = true;
                Ambiance1.Stop();
                Ambiance2.Play();
            }
        }
            
        //si pv joueur sont a 0
        if (Life.nbLife<=0)
        { game_over(); }
    }

    void game_over()
    {
        //joue musique fin
        GameOverFx.Play();
        //active l'image gameover
        UiGameOver.SetActive(true);
        //pause le joueur
        Time.timeScale = 0;
    }
}
