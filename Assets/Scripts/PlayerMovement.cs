using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    public float speed = 1.0f;

    private Rigidbody2D rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        Ray ray = new Ray(transform.position, direction);
        Debug.DrawRay(ray.origin, ray.direction*direction.magnitude, Color.red);

        Vector3 velocity = Vector3.ClampMagnitude(direction * speed, speed);


        //rbody.MovePosition(transform.position + velocity * Time.deltaTime);
        rbody.velocity = velocity;
        // Debug.Log("Current U/s: " + velocity.magnitude);
        Vector3 scale = transform.localScale;
        scale.x = (velocity.x <= 0) ? -1 : 1;
        transform.localScale = scale;

        if (Debug.isDebugBuild && Input.GetKeyDown(KeyCode.F1))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
