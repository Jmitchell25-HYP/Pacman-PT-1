using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CoinCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
       
        }
    }
}
