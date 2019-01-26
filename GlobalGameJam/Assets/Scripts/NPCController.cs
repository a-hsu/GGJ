using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField]
    Rigidbody NPCRigidBody;

    // Update is called once per frame
    void Update()
    {

    }

    void HopAnimation()
    {
        NPCRigidBody.AddForce()
    }
}
