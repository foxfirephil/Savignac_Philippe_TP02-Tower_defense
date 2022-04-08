using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static int level;
    public bool IsStart=false;
    public static int nbEnn;
    public GameObject UiGameOver;

    AudioSource GameOverFx;
    AudioSource Ambiance1;
    AudioSource Ambiance2;

    public GameObject spawn;

    float waveTimer = 20f;
    bool IsRoundActive = false;
    bool TimerActive = true;
    public static int nbEnnWave;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        spawn.SetActive(false);
        GameOverFx = GetComponent<AudioSource>();
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
                level++;
                IsRoundActive = true;
                nbEnnWave = 10 + level * 4;
                TimerActive = false;

            }
        }

        if(IsRoundActive)
        {
            spawn.SetActive(true);
            Debug.Log(nbEnnWave);
            if (nbEnnWave<=0)
            {
                spawn.SetActive(false);
                IsRoundActive = false;
                waveTimer = 15f;
                TimerActive = true;
            }
        }
            

        if (Life.nbLife<=0)
        { game_over(); }
    }

    void game_over()
    {
        Time.timeScale = 0;
        UiGameOver.SetActive(true);
        GameOverFx.Play();
    }
}
