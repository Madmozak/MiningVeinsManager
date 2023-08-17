using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ResourceNodes : MonoBehaviour, IInteractable
{
    [SerializeField] ResourceNode commonResourceNode;
    [SerializeField] ResourceNode rareResourceNode;
    ResourceNode spawnedResourceNode;
    bool isResourceNodeSpawned;
    public Action OnCollectMaterials;

    public bool IsResourceNodeSpawned { get => isResourceNodeSpawned; set => isResourceNodeSpawned = value; }

    // Start is called before the first frame update
    void Start()
    {
        DisableResourceNode(commonResourceNode);
        DisableResourceNode(rareResourceNode);
        isResourceNodeSpawned = false;

    }


    public void SpawnResource()
    {
        if(ResourcesSpawnManager.Instance.GetRandomInt100() < ResourcesSpawnManager.Instance.RareResourceSpawnChance)
        {
            EnableResourceNode(rareResourceNode);
            spawnedResourceNode = rareResourceNode;
        }
        else
        {
            EnableResourceNode(commonResourceNode);
            spawnedResourceNode = commonResourceNode;
        }
    }

    void CollectResourceNode()
    {
        DisableResourceNode(spawnedResourceNode);
        spawnedResourceNode = null;
        OnCollectMaterials?.Invoke();
    }

    public void EnableResourceNode(ResourceNode resourceNode)
    {
        resourceNode.gameObject.SetActive(true);
        isResourceNodeSpawned = true;
    }

    public void DisableResourceNode(ResourceNode resourceNode)
    {
        resourceNode.gameObject.SetActive(false);
        isResourceNodeSpawned = false;
    }

    public void Interact()
    {
        //Collect Mateirals
        CollectResourceNode();
    }
}
