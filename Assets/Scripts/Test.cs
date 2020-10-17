using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ImmediatelyRotation();
    }

    public void ImmediatelyRotation()
    {
        Vector3 playerPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(playerPosition, transform.forward);
    }
}
