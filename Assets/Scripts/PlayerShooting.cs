using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShooting : MonoBehaviour {

    public int damagePerShot = 1;
    public float timeBetweenBullets = 0.20f;
    public float initialSpeed = 2f;

    public int critChance = 10;
    public int critScale = 5;

    public GameObject bulletPrefab;
    
    private float timer;
    private Rigidbody2D playerRbody;
    private Transform bulletHolder;

    private void Awake()
    {
        playerRbody = GetComponent<Rigidbody2D>();
        bulletHolder = GameObject.Find("BulletHolder").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
        }
        

    }

    void Shoot()
    {
        timer = 0f;

        Vector2 playerToMouseVector = (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);

        float angle = Vector2.SignedAngle(Vector2.right, playerToMouseVector);

        GameObject toInstatiate = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0,0,angle), bulletHolder);
        if (Random.Range(0, 100) < critChance)
            toInstatiate.transform.localScale *= critScale;
        

        toInstatiate.GetComponent<Rigidbody2D>().velocity = playerToMouseVector.normalized * initialSpeed;
    } 
}
