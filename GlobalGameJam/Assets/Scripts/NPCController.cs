using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Rigidbody NPCRigidBody;
    float yLimit = 0;
    bool up = true;
    // Start is called before the first frame update
    void Start()
    {
        NPCRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
    }

    void Animate()
    {
        if(up)
        {
            ++yLimit;

            if(yLimit==1)
            {
                up = false;
            }
        }

        else
        {
            --yLimit;

            if(yLimit==0)
            {
                up = true;
            }
        }
       

        
        //else if(yLimit > 0)
        NPCRigidBody.AddForce(new Vector3(0, yLimit, 0));
    }
}
