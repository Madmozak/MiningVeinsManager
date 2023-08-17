using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesSpawnManager : MonoBehaviour
{
    private ResourcesSpawnManager instance;
    public ResourcesSpawnManager Instance { get => instance; }

    [SerializeField] List<MetalDeposit> ironGoldDepositList = new();

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
