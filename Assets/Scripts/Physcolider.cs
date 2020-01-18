using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physcolider : MonoBehaviour
{
    private float currentSpeed;
    private float collisionSpeed;
    private bool bumped;

    private Rigidbody _body;

    // Start is called before the first frame update
    void Start()
    {
        _body = this.GetComponentInParent<Rigidbody>();
        Debug.Log("collider init.");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            Debug.Log("Player hit!!");
            if (currentSpeed > 3)
            {
                collisionSpeed = currentSpeed;
                bumped = true;
            }
        }
        else
        {
            Debug.Log("Hit something else " + collision.collider.gameObject.tag);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        currentSpeed = _body.velocity.magnitude;

        if (bumped)
        {
            //health -= collisionSpeed - currentSpeed;
            Debug.Log("Player Pumped!!");

            bumped = false;
        }
    }
}
