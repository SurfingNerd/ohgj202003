using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{


    GameObject m_Player;
    UnityEngine.AI.NavMeshAgent m_NavMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        if (m_Player == null) 
        {
            Debug.LogError("Unable to find Player to follow!");
            this.enabled = false;
        }
        m_NavMeshAgent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (m_NavMeshAgent == null) 
        {
            Debug.LogError("Unable to find NAvMeshAgent!");
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        m_NavMeshAgent.SetDestination(m_Player.gameObject.transform.position);

        if (Vector3.Distance(m_Player.gameObject.transform.position, transform.position) < 1.5)
        {
            UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene(); 
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);

        }
    }
}
