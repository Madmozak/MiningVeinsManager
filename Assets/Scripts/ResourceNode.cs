using System;
using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    ScriptableObject resource;
    public Action OnCollectMaterials;


    void Start()
    {
        
    }

    public void CollectMaterials()
    {
        //add materials to inventory
        OnCollectMaterials?.Invoke();
        DisableNode();
    }

    public void EnableNode()
    {
        gameObject.SetActive(true);
    }

    public void DisableNode()
    {
        gameObject.SetActive(false);
    }

}
