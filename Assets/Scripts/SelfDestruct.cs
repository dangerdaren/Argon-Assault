using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 3;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
