
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tragget : MonoBehaviour
{
    private float lifeTime = 2f;

    private GameManager gameManagerScript;

    public int points;
    public GameObject ParticleSystem;
    void Start()
    {
        // Autodestrucción tras 2 segundos
        gameManagerScript = FindObjectOfType<GameManager>();
        lifeTime = gameManagerScript.spawnRate;
        Destroy(gameObject, lifeTime);
    }

    private void OnMouseDown()
    {
        if (!gameManagerScript.isGameOver)
        {
            gameManagerScript.updateScore(points); //Permite sumar los puntos de cada objeto
            Instantiate(ParticleSystem, transform.position, ParticleSystem.transform.rotation);
            //Si le damos a un objeto este desaparece
            Destroy(gameObject);

            //si le damos a la calavera GameOver
            if (gameObject.CompareTag("Bad"))
            {
                gameManagerScript.GameOver();
            }
        }
    }

    private void OnDestroy()
    {
        gameManagerScript.targetPosition.Remove(transform.position);
    }
}