﻿using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour 
{
    public GameObject cube;
    public GameObject item;

    private System.String[] cubeTags = { "Target Azul", "Target Vermelho", "Target Amarelo", "Untagged", "Item" };

    private GameMananger gameManager;

    private float timing;

	// Use this for initialization
	void Start () 
    {
        timing = 0;
        // Getting access to other scripts
        gameManager = this.gameObject.GetComponent<GameMananger>();
	}

    public void SpawnObject(float direction, float intensity)
    {
        if (Random.Range(0, 100) < 80)
            CreateTarget(cube, CubeColor(), direction, intensity);
        else
            CreateTarget(item, 5, direction, intensity);
    }

    private int CubeColor()
    {
        int roulette = Random.Range(0, 100);
        if (roulette < 33)
            return 1;
        else if (roulette < 66)
            return 2;
        else
            return 3;
    }

    private void CreateTarget(GameObject targetType, int cubeColor, float direction, float intensity)
    {
        GameObject newTarget = Instantiate(targetType, new Vector3(Random.Range(-3.4f, 3.4f), 6.2f, -1f), Quaternion.identity) as GameObject;
        gameManager.AddObjectToList(newTarget);

        // Setting color properties
        newTarget.GetComponent<TargetColor>().Color = cubeColor;
        newTarget.transform.tag = cubeTags[cubeColor - 1]; // Set the tag

        // Adding the velocity and instantiate
        //print("Direction: " + direction + "; Intensity: " + intensity);
        newTarget.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(direction, -intensity, 0));
    }
}
