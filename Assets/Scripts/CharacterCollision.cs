using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            Debug.Log("CHAR: Player hit!!");
            //if (currentSpeed > 3)
            //{
            //    collisionSpeed = currentSpeed;
            //    bumped = true;
            //}
        }
        else
        {
            Debug.Log("CHAR: Hit something else " + collision.collider.gameObject.tag);
        }
    }
}
