using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        ProcessCollision(other.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        ProcessCollision(other.gameObject);
    }

    void ProcessCollision(GameObject collider)
    {
        if (collider.CompareTag("Damage"))
        {
            DoDamageToCar();
        }
    }

    void DoDamageToCar()
    {
        Debug.Log("Hit!");
    }
}
