using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///This class I guess would take the place of OnProjectileTriggerable or something from the scriptableObjects tutorial we did???
public class ProjectileAbilityHandler : MonoBehaviour
{

    [HideInInspector] public GameObject projectile;
    public Transform projectileSpawnPoint;
    [HideInInspector] public float projectileForce = 300f;

    public void Launch()
    {
        GameObject cloneProjectile = Instantiate(projectile, projectileSpawnPoint.position, transform.rotation);
        Rigidbody cloneRB = cloneProjectile.GetComponent<Rigidbody>();
        cloneRB.AddForce(projectileSpawnPoint.transform.forward * projectileForce);
        
    }
}
