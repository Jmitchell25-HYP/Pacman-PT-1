using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class Enemymover : MonoBehaviour
{
    public Transform targetObj;
  

    void Start()
    {

    }

    void Update()
    { targetObj.position = transform.position;
        Transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, 10 * Time.deltaTime);
    }

}



