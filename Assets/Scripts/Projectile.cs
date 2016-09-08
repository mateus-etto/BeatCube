﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
    Renderer projectileRenderer;
    Color projectileColor, white;

    void Start()
    {
        projectileRenderer = GetComponent<Renderer>();
        white = new Color(1, 1, 1);
    }

    void Update()
    {
        if (SpecialManager.SpecialActivated)
            PaintShpere(white);
        else
            PaintShpere(projectileColor);
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

    void OnTriggerEnter(Collider Col)
    {
        // When hitting on the wall
        if (Col.gameObject.tag.Equals("Parede"))
        {
            Vector3 vetorAux = transform.GetComponent<Rigidbody>().velocity;
            vetorAux.x *= -1;
            transform.GetComponent<Rigidbody>().velocity = vetorAux;
        }
        // If, form some reason, the cube is going up instead of down 
        else if (Col.gameObject.tag.Equals("Teto"))
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        GameObject.Find("GameManager").GetComponent<GameMananger>().RemoveObjectFromList(this.gameObject);
    }
}
