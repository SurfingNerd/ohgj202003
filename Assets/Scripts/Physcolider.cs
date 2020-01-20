using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Physcolider : MonoBehaviour
{
    private float currentSpeed;
    private float collisionSpeed;
    private bool bumped;

    private Rigidbody _body;

    private GameObject _oofObject;

    // Start is called before the first frame update
    void Start()
    {

        _body = this.GetComponentInParent<Rigidbody>();
        //Debug.Log("collider init.");
        //Scene scene = SceneManager.GetActiveScene();
        //Physics.gravity = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            Debug.Log("Player hit!! " + currentSpeed.ToString("#.###"));
            if (currentSpeed > 6)
            {
                collisionSpeed = currentSpeed;
                bumped = true;
            }
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
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            bumped = false;
        }
    }
}
