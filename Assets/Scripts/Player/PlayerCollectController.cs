using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectController : MonoBehaviour
{
    [SerializeField] private Player player;
    private void OnTriggerEnter(Collider other)
    {
        CollectableObject collectableObject = other.GetComponent<CollectableObject>();

        if (collectableObject != null)
        {
            Debug.Log("Collectable Enter: " + collectableObject.name);
            collectableObject.Collect(player);
        }
    }
}
