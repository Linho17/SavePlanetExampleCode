using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{

    public static GameStats instance;
    private bool isPlay = false;
    
    private bool isNewGame = true;
    [SerializeField] private SpawnZone spawnZone;
    [SerializeField] private CleverUI cleverUI;
    [SerializeField] private TrashCansControl cansControl;

    [SerializeField] private ParticleSystem gameOverEffect;
    [SerializeField] private ParticleSystem gameWinEffect;
    [SerializeField] private Light light;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private AudioClip[] audioClips;


    public bool IsPlay
    {
        get { return isPlay; }
        private set
        {
            isPlay = value;
            light.enabled = isPlay;
            Time.timeScale = isPlay ? 1 : 0;
            if (isPlay) audioSource.Play();
            else audioSource.Pause();
        }
    }

    [SerializeField] private int targetPoints;
    private void Awake()
    {
        if (instance == null) instance = this;
    }


    private int health;
    private int points;
    private bool isMute = false;

    public static int POINTS
    {
        set
        {
            instance.points = value;
            instance.UpdatePoints();
            if(instance.points == instance.targetPoints)
            {
                instance.GameWin();
            }
        }

        get
        {
            return instance.points;
        }
    }

    private void GameWin()
    {
        cleverUI.GetComponent<Animator>().enabled = true;
        gameWinEffect.Play();
        IsPlay = false;
        spawnZone.StopSpawn();

    }

    public static int HEALTH
    {
        set
        {
            instance.health = value;
            
            
            if (instance.health <= 0)
            {
                instance.health = 0;
                instance.GameOver();
            }
            instance.UpdateHealth();
        }
        get
        {
            return instance.health;
        }
    }

    private void UpdateHealth()
    {
        cleverUI.UpdateCleverUI(HEALTH);
    }

    private void UpdatePoints()
    {
        cleverUI.UpdateCleverFill((float)POINTS / (float)targetPoints);
    }


    public void GameOver()
    {
        IsPlay = false;
        spawnZone.StopSpawn();
        
        gameOverEffect.Play();
        cansControl.GameOver();
        
        isNewGame = true;
    }

    public void Reset()
    {
        cansControl.GameOver();
        spawnZone.StopSpawn();
        gameOverEffect.Stop();
        gameOverEffect.Clear();
        gameWinEffect.Stop();
        gameWinEffect.Clear();
        
        isNewGame = true;
        StartGame();
    }

    private void Update()
    {
        if (!audioSource.isPlaying && isPlay)
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
        }
    }

    public void StartGame()
    {
        if (isNewGame)
        {
                   
            audioSource.Stop();
            audioSource.clip = audioClips[0];
            IsPlay = true;
            isNewGame = false;
            
            cansControl.Reset();
            HEALTH = 3;
            POINTS = 0;
            spawnZone.StartSpawn();

            gameOverEffect.Stop();
            gameOverEffect.Clear();
            gameWinEffect.Stop();
            gameWinEffect.Clear();

            cleverUI.GetComponent<Animator>().enabled = false;
            

        }
        else
        {
            IsPlay = !IsPlay;
        }
        
        

    }


    public void MuteBtn()
    {
        isMute = !isMute;
        audioSource.mute = isMute;
        foreach  (AudioSource a in audioSources)
        {
            a.mute = isMute;
        }
    }
}
