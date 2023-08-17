using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesSpawnManager : MonoBehaviour
{
    private static ResourcesSpawnManager instance;
    public static ResourcesSpawnManager Instance { get => instance; }
    public int RareResourceSpawnChance { get => rareResourceSpawnChance; set => rareResourceSpawnChance = value; }

    [SerializeField] List<ResourceNode> ironGoldDepositList = new();
    [SerializeField] int rareResourceSpawnChance = 10;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitialSpawnResources()
    {

    }


}
