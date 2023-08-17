using System;
using UnityEngine;

public class ResourceNode : MonoBehaviour, IInteractable
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

    public void Interact()
    {
        CollectMaterials();
    }
}
