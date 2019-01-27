using System.Collections.Generic;
using UnityEngine;

public class NPCSpawnController : MonoBehaviour
{
    //We can change this number depending on the level.
    public int NPCSPawnNumber = 1;

    public List<GameObject> NPCs;
    public GameObject NPCPrefab;
    public MeshRenderer areaMeshRenderer;

    enum NPCDistance
    {
        NEAR = 0,
        MEDIUM = 1,
        FAR = 2
    }

    void SpawnNPC(int NPCCount)
    {
        for (int NPCNumber = 0; NPCNumber < NPCCount; ++NPCNumber)
        {
            int distance = Random.Range((int)NPCDistance.NEAR, (int)NPCDistance.FAR);
            GameObject NPC = Instantiate(NPCPrefab);

            setNPCPosition(NPC, distance);

            NPCs.Add(NPC);
        }
    }

    void setNPCPosition(GameObject NPC, int distance)
    {
        float xPosition = 0.0f;
        float zPosition = 0.0f;

        if (distance == (int)NPCDistance.NEAR)
        {
            xPosition = 0.25f * areaMeshRenderer.bounds.max.x;
            zPosition = 0.25f * areaMeshRenderer.bounds.max.z;
        }

        else if (distance == (int)NPCDistance.MEDIUM)
        {
            xPosition = 0.50f * areaMeshRenderer.bounds.max.x;
            zPosition = 0.50f * areaMeshRenderer.bounds.max.z;
        }

        else if (distance == (int)NPCDistance.FAR)
        {
            xPosition = 0.75f * areaMeshRenderer.bounds.max.x;
            zPosition = 0.75f * areaMeshRenderer.bounds.max.z;
        }

        Rigidbody NPCRigdBody = NPC.GetComponent<Rigidbody>();

        NPCRigdBody.position=new Vector3(xPosition, 0.0f, zPosition);
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnNPC(NPCSPawnNumber);
    }
}
