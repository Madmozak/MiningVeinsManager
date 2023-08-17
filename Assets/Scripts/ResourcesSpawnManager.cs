using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesSpawnManager : MonoBehaviour
{
    [SerializeField]private static ResourcesSpawnManager instance;
    public static ResourcesSpawnManager Instance { get => instance; }
    public int RareResourceSpawnChance { get => rareResourceSpawnChance; set => rareResourceSpawnChance = value; }

    [SerializeField] List<ResourceNodes> ironGoldDepositList = new();
    [SerializeField] int rareResourceSpawnChance = 10;
    [SerializeField] float timeToSpawnResourceNode = 30;
    float timerForSpawn;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        InitialSpawnResources();
    }

    // Update is called once per frame
    void Update()
    {
        PeriodicResourceNodeSpawnLogic();
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
        foreach (ResourceNodes resourceNodes in ironGoldDepositList)
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
        foreach (ResourceNodes item in ironGoldDepositList)
        {
            if(GetRandomInt100() >= 50)
            {
                item.SpawnResource();
            }
        }
    }

    public int GetRandomInt100() => Random.Range(0, 100);


}
