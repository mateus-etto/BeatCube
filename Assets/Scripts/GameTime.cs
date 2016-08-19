﻿using UnityEngine;
using System.Collections;

public class GameTime : MonoBehaviour 
{
    float tempo;
    float tempoInicio;
    BackgroundAnimation scriptMusica;
    GUIText guiText;

	void Start () 
    {
        tempo = 0;
        tempoInicio = Time.time;
        scriptMusica = GameObject.Find("Background").GetComponent<BackgroundAnimation>();
        guiText = GetComponent<GUIText>();
	}
	
	void Update () 
    {
        guiText.color = scriptMusica.DevolveCor();
        tempo = Time.time - tempoInicio;
        guiText.text = Mathf.RoundToInt(tempo).ToString();
    }

    public float TimeElapsed()
    {
        return Mathf.RoundToInt(tempo);
    }
}
