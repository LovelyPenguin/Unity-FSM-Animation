using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIWeapon : MonoBehaviour
{
    [Header("Necessary Setting")]
    public UnityEvent playerTriggerEnter;
    public AIManager ai;
    [Header("Basic Setting")]
    public bool useAttack;
    public bool useTrigger;
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
        }
    }
}
