using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//only script load scene

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 2f;
    [Tooltip("FX Prefab on player")][SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        StartCoroutine(ReloadScene());
    }

    private void StartDeathSequence()
    {
        gameObject.SendMessage("PlayerDeath");
    }

    IEnumerator ReloadScene()      //string reference
    {
        yield return new WaitForSeconds(levelLoadDelay);
        SceneManager.LoadScene("GameOver");
    }
}
