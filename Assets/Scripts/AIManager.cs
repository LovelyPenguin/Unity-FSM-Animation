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
    public List<GameObject> weapon;
    [HideInInspector]
    public float damageFactor;
    [HideInInspector]
    public float knockBackFactor;

    private float extraRotationSpeed = 5f;
    private bool isAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerRig = player.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        //nav.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        anim.SetFloat("Distance", distance);
        //ImmediatelyRotation();

        if (!isAttack)
        {
            TempSolution();
        }
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
        isAttack = false;
    }

    public void Attack()
    {
        nav.isStopped = true;
        isAttack = true;
        if (distance <= 1.9f)
        {
            anim.SetInteger("AttackRandom", 1);
        }
        else
        {
            anim.SetInteger("AttackRandom", Random.Range(2,5));
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
        playerRig.AddForce(transform.forward * knockBackFactor, ForceMode.Impulse);
    }

    public void WeaponTriggerOn(int index)
    {
        weapon[index].SetActive(true);
    }
    public void WeaponTriggerOff(int index)
    {
        weapon[index].SetActive(false);
    }

    public void LookAtUpdate()
    {
        //transform.LookAt(player.position, transform.forward);
    }

    public void SetDamage(float value)
    {
        damageFactor = value;
    }
    public void SetKnockBack(float value)
    {
        knockBackFactor = value;
    }

    public void ImmediatelyRotation()
    {
        Debug.Log("ROTATION");
        Vector3 playerPosition = new Vector3(
            player.position.x, 
            0, 
            player.position.z);
        transform.LookAt(playerPosition);
    }

    public void TempSolution()
    {
        Vector3 lookrotation = nav.steeringTarget - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), extraRotationSpeed * Time.deltaTime);
    }
}
