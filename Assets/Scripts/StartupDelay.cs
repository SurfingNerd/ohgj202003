using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupDelay : MonoBehaviour
{

    

     UnityStandardAssets.Cameras.FreeLookCam m_freeLookCam;

    public AnimationCurve CameraSpeedAnimationCurve  = new AnimationCurve(); 
    public float StartupDelayDuration = 5.0f;

    public float MaxCameraSpeed = 2.0f;

    public float MinCameraSpeed = 1.0f;

    private float m_startupTime = 0;

    // Start is called before the first frame update
    void Start()
    {

        m_freeLookCam = this.GetComponentInParent< UnityStandardAssets.Cameras.FreeLookCam>();  
        Physics.gravity = Vector3.zero;
        
        m_startupTime = Time.time;

        //Debug.Log("collider init.");
        //Scene scene = SceneManager.GetActiveScene();

        

    }

    void Update()
    {
        float timePassed = Time.time - m_startupTime;
        if ( timePassed < StartupDelayDuration ) // are we still in the startup delay ?
        {
            var evaluated = CameraSpeedAnimationCurve.Evaluate(timePassed / StartupDelayDuration);

            m_freeLookCam.m_MoveSpeed = 1; //dw MinCameraSpeed + (evaluated * MaxCameraSpeed);
            Debug.Log("evaled: :" + evaluated + " " + "MoveSpeed :" + m_freeLookCam.m_MoveSpeed);
        }
        else
        {
            Debug.LogError("Reactivating Gravity");

            var character =  GameObject.FindWithTag("Player").GetComponent< UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().m_JumpPower = 7;


            Physics.gravity = Vector3.down * 9.8f;
            Destroy(this);
        }
        
    }
}