using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesSpawnManager : MonoBehaviour
{
    private static ResourcesSpawnManager instance;
    public static ResourcesSpawnManager Instance { get => instance; }
    public int RareResourceSpawnChance { get => rareResourceSpawnChance; set => rareResourceSpawnChance = value; }
    public List<ResourceNodes> IronGoldDepositList { get => ironGoldDepositList; set => ironGoldDepositList = value; }

    [SerializeField] List<ResourceNodes> ironGoldDepositList = new();
    [SerializeField] int rareResourceSpawnChance = 10;
    [SerializeField] float timeToSpawnResourceNode = 30;
    float timerForSpawn;
    [SerializeField] int lowAmountOfResourceNodes = 2;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitialSpawnResources();
        SubscribeToResourceNodesCollection();
    }

    // Update is called once per frame
    void Update()
    {
        PeriodicResourceNodeSpawnLogic();
    }

    void SpawnOnLowResourceNodes()
    {
        int i = 0;
        foreach (ResourceNodes resourceNodes in IronGoldDepositList)
        {
            if (resourceNodes.IsResourceNodeSpawned)
            {
                i++;
            }

        }

        if (i <= lowAmountOfResourceNodes)
        {
            SpawnRandomResourceNode();
        }
    }

    void SubscribeToResourceNodesCollection()
    {
        foreach (ResourceNodes resourceNodes in IronGoldDepositList)
        {
            resourceNodes.OnCollectMaterials += SpawnOnLowResourceNodes;
        }
    }

    void PeriodicResourceNodeSpawnLogic()
    {
        timerForSpawn += Time.deltaTime;
        if (timerForSpawn >= timeToSpawnResourceNode)
        {
            SpawnRandomResourceNode();
            timerForSpawn = 0;
        }
    }


    void SpawnRandomResourceNode()
    {
        ResourceNodes rns = GetNotSpanwedResourceNode();
        if(rns != null)
        {
            rns.SpawnResource();
        }
    }

    ResourceNodes GetNotSpanwedResourceNode()
    {
        foreach (ResourceNodes resourceNodes in IronGoldDepositList)
        {
            if (!resourceNodes.IsResourceNodeSpawned)
            {
                return resourceNodes;
            }
        }

        return null;
    }

    void InitialSpawnResources()
    {
        foreach (ResourceNodes item in IronGoldDepositList)
        {
            if(GetRandomInt100() >= 50)
            {
                item.SpawnResource();
            }
        }
    }

    public int GetRandomInt100() => Random.Range(0, 100);


}
