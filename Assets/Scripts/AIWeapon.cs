using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIWeapon : MonoBehaviour
{
    public UnityEvent playerTriggerEnter;
    public AIManager ai;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTriggerEnter.Invoke();
            Debug.Log("Damage : " + ai.damageFactor);
        }
    }
}
