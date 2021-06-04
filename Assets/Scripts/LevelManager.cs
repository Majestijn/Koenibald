using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class LevelManager : MonoBehaviour
{
    public PlayerController thePlayer;
    public FinishedGameController koenibald;
    public MainMusicStopController music;
    public string levelname;//dit is de levelname, bij het startschermscript zie je in de switchstatement bijvoorbeeld seaDead of seaVictory. Deze string is dan het eerste gedeelte dus sea, sewer of school
    private int counter;
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();//vind de player
        koenibald = FindObjectOfType<FinishedGameController>();
        music = FindObjectOfType<MainMusicStopController>();
    }

    void Update()
    {
        if (thePlayer.gameOver)//als de player gameover is laad gameover scherm
        {
            music.stop();
            if (!thePlayer.audioData.isPlaying)
            {
                Time.timeScale = 0;
                loadScene("Dead");
            }
        }
        else if (thePlayer.victory)
        {
            music.stop();
            if (!koenibald.audioData.isPlaying)
            {
                loadScene("Victory");
            }
        }
    }
 

    public void loadScene(string state)
    {
        Scenes.Load("StartScherm", levelname + state);//laad startscherm en sla de waarde op in scenes
    }
}