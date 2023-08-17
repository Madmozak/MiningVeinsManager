using System;
using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    ScriptableObject resource;



    public void CollectMaterials()
    {
        //add materials to inventory

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
