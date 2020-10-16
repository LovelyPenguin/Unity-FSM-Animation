using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour
{
    private NavMeshAgent nav;
    private Animator anim;
    public Transform player;
    public Rigidbody playerRig;
    public float distance;
    public float pushPower;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerRig = player.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        anim.SetFloat("Distance", distance);
    }

    public void RunToTarget()
    {
        nav.isStopped = false;
        nav.SetDestination(player.position);
        nav.speed = 5f;
    }

    public void WalkToTarget()
    {
        nav.isStopped = false;
        nav.SetDestination(player.position);
        nav.speed = 1f;
    }

    public void Idle()
    {
        nav.isStopped = true;
    }

    public void Attack()
    {
        Idle();
        if (distance <= 1.3f)
        {
            anim.SetInteger("AttackRandom", 1);
        }
        else
        {
            anim.SetInteger("AttackRandom", Random.Range(2,4));
        }
    }

    public void SetAttackCode(int value)
    {
        anim.SetInteger("AttackRandom", value);
    }

    public void Push()
    {
        Debug.Log("Push");
        Vector3 pushDirection = (player.position - transform.position).normalized;
        playerRig.AddForce(transform.forward * pushPower, ForceMode.Impulse);
    }

    public void PushSettingValue(int value)
    {
        Debug.Log("Push Setting Value");
        Vector3 pushDirection = (player.position - transform.position).normalized;
        playerRig.AddForce(transform.forward * value, ForceMode.Impulse);
    }
}
