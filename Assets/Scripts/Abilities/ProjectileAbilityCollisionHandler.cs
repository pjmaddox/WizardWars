using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAbilityCollisionHandler : MonoBehaviour
{
    private System.Action<Collision, GameObject> onCollisionFunction;

    public void PrimeProjectile(System.Action<Collision, GameObject, ProjectileAbilityStats> onCollision, ProjectileAbilityStats stats)
    {
        this.onCollisionFunction = (Collision other, GameObject ob) => {
            onCollision(other, ob, stats);
        };
    }

    private void OnCollisionEnter(Collision other)
    {
        this.onCollisionFunction(other, this.gameObject);
        Destroy(this, .25f);
    }
}
