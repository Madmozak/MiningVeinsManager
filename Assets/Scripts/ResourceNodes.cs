using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNodes : MonoBehaviour
{
    [SerializeField] ResourceNode commonResourceNode;
    [SerializeField] ResourceNode rareResourceNode;

    // Start is called before the first frame update
    void Start()
    {
        commonResourceNode.DisableNode();
        rareResourceNode.DisableNode();
    }

    public void SpawnResource(int i)
    {
        if(i < ResourcesSpawnManager.Instance.RareResourceSpawnChance)
        {
            rareResourceNode.EnableNode();
        }
        else
        {
            commonResourceNode.EnableNode();
        }
        
    }

}
