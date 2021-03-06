﻿using UnityEngine;
using System.Collections;

public class Projectile : WallDetector 
{
    private Renderer projectileRenderer;
    private Color projectileColor, white;

    void Start()
    {
        base.Start();
        projectileRenderer = GetComponent<Renderer>();
        white = new Color(1, 1, 1);
    }

    void Update()
    {
        base.Update();
        CheckIfOnScreen();
        if (SpecialManager.SpecialActivated)
            PaintShpere(white);
        else
            PaintShpere(projectileColor);
    }

    private void CheckIfOnScreen()
    {
        // Did not hit a cube
        if (transform.position.y >= 8)
            Destroy(this.gameObject);
    }

    public void SphereColor(int colorId)
    {
        switch (colorId)
        {
            case 1:
                projectileColor = new Color(0.5f, 1, 1);
                break;
            case 2:
                projectileColor = new Color(1, 0.5f, 1);
                break;
            case 3:
                projectileColor = new Color(1, 1, 0.5f);
                break;
        }
    }

    private void PaintShpere(Color sphereColor)
    {
        projectileRenderer.material.color = sphereColor;
    }
}
