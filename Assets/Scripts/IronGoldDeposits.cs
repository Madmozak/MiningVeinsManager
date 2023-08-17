using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronGoldDeposits : MonoBehaviour
{
    [SerializeField] IronDeposit commonResource;
    [SerializeField] GoldDeposit rareResource;

    private void Start()
    {
        DisableResource(commonResource);
        DisableResource(rareResource);
    }

    public void SpawnResource()
    {
        int i = Random.Range(0, 100);
        if(i > 80)
        {
            EnableResource(rareResource);
        } else
        {
            EnableResource(commonResource);
        }
    }

    private void EnableResource(Resource resource)
    {
        resource.gameObject.SetActive(true);
    }

    private void DisableResource(Resource resource)
    {
        resource.gameObject.SetActive(false);
    }
}
