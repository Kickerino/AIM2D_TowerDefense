﻿using UnityEngine;
using System.Collections;

public class healthChange : MonoBehaviour {
    public GameObject Player;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    private SpriteRenderer spriteRenderer;

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
        if (Player.GetComponent<movement>().PlayerLives == 6)
        {
            spriteRenderer.sprite = sprite1;
        }
        if (Player.GetComponent<movement>().PlayerLives == 5) 
        {
            spriteRenderer.sprite = sprite2;
        }
        if (Player.GetComponent<movement>().PlayerLives == 4)
        {
            spriteRenderer.sprite = sprite3;
        }
	}
}
