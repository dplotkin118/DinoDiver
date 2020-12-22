using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;


    void Start(){
      Debug.Log(enemyLayer);
      Debug.Log(LayerMask.GetMask("boss"));
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
        Debug.Log(enemyLayer);
    }

    void Attack()
    {
        // animator.SetTrigger("Melee");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {

            if(enemyLayer == 1024){
              Debug.Log("im here");
              enemy.GetComponent<BossDefeat>().TakeDamage(100,enemy.gameObject);
            }
            else{
              enemy.GetComponent<Knockback>().TakeDamage(100, enemy.gameObject);
            }
        }
        //
        // void OnDrawGizmosSelected()
        // {
        //     if (attackPoint == null)
        //     {
        //         return;
        //     }
        //
        //     Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        // }
    }
}
