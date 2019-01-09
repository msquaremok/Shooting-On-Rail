using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerDeath = 40;
    [SerializeField] int hp = 200;

    ScoreBoard scoreBoard;

	// Use this for initialization
	void Start ()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
	}

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ReduceHP(other);
        //todo consider hit FX
        if (hp <= 0)
        {
            ExecuteDeath();
        }
    }

    private void ReduceHP(GameObject other)
    {
        int damage = other.GetComponent<DamageDealer>().GetDamage();
        hp -= damage;
    }

    private void ExecuteDeath()
    {
        scoreBoard.ScoreHit(scorePerDeath);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
