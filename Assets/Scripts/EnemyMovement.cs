using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public Transform playerCheck;
    public float detectionRadius = 5f;
    public LayerMask whatIsPlayer;
    public float speed = 2f;
    bool playerDetected = false;
    private Vector2 target;




    // Use this for initialization
    void Start()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    // Update is called once per frame
    void Update()
    {

        playerDetected = Physics2D.OverlapCircle(playerCheck.position, detectionRadius, whatIsPlayer);
        

        target = player.transform.position;

        if (playerDetected)
        {
            transform.position = Vector2.MoveTowards(playerCheck.position, target, speed * Time.deltaTime);
            playerDetected = false;
        }


    }
}
