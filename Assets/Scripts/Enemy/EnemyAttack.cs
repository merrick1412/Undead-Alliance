using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float damageAmnt;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControls>()) //checks to see if enemy touched player
        {
            //grabs player's health controller
            var healthController = collision.gameObject.GetComponent<PlayerHealthController>();

            healthController.TakeDamage(damageAmnt);
        }
    }
}
