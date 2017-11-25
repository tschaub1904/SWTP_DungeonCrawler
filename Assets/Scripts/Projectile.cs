using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public Transform particleSpawner;

    private bool destroyed = false;

    void Awake()
    {
        particleSpawner = GameObject.FindObjectOfType<ParticleSystem>().transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!destroyed)
        {
            DestroyOnCollision();
            EmitParticlesAtPosition();
        }
    }

    public void DestroyOnCollision()
    {
        Destroy(this.gameObject);
        destroyed = true;
    }
    public void EmitParticlesAtPosition()
    {
        Vector3 position = particleSpawner.position;
        position.x = transform.position.x;
        position.y = transform.position.y;
        particleSpawner.position = position;

        particleSpawner.GetComponent<ParticleSystem>().Emit(3);
    }
}
