using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    bool grounded=true;
    float hopHeight=5.0f;
    Vector3 hopDirection;

    [SerializeField]
    Rigidbody NPCRigidBody;

    AudioSource source;

    void Start()
    {
        hopDirection.Set(0.0f, hopHeight, 0.0f);
    }

    void Update()
    {
        HopAnimation();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Floor"&&!grounded)
        {
            grounded=true;
        }
    }

    void HopAnimation()
    {
        if(grounded)
        {
            NPCRigidBody.AddForce(hopDirection, ForceMode.Impulse);
            grounded=false;
        }
    }
}
