using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyInteractScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetSpawnedResourceNode().Interact();
        }
    }

    ResourceNodes GetSpawnedResourceNode()
    {
        foreach (ResourceNodes resourceNodes in ResourcesSpawnManager.Instance.IronGoldDepositList)
        {
            if (resourceNodes.IsResourceNodeSpawned)
            {
                return resourceNodes;
            }
        }

        return null;
    }


}
