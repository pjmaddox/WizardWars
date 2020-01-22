using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///This class I guess would take the place of OnProjectileTriggerable or something from the scriptableObjects tutorial we did???
public class ProjectileAbilityHandler : MonoBehaviour
{

    [HideInInspector] public GameObject projectile;
    public Transform projectileSpawnPoint;
    
    [HideInInspector] public float projectileForce = 300f;

    public void Launch(ProjectileAbility ability)
    {
        RaycastHit hit;
        Vector3 targetRotation = transform.forward;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
        {
            targetRotation = hit.point - projectileSpawnPoint.transform.position;
            targetRotation.Normalize();
            

        }

        GameObject cloneProjectile = Instantiate(ability.projectileToSpawn, projectileSpawnPoint.position + ability.launchOffSet, transform.rotation);

        Rigidbody cloneRB = cloneProjectile.GetComponent<Rigidbody>();
        cloneRB.AddForce(targetRotation * ability.projectileForce);
        
        Destroy(cloneProjectile, 5f);

        ProjectileAbilityStats pas = cloneProjectile.GetComponent<ProjectileAbilityStats>();
        pas.force = ability.projectileForce;
        pas.damage = ability.damage;
        cloneProjectile.tag = "ability";
        
        //Add ProjectileAbilityCollisionHandler to projectile?
        System.Action<Collision, GameObject, ProjectileAbilityStats> collisionHandlerFunction = OnCollide;
        var onCollisionScript = cloneProjectile.AddComponent<ProjectileAbilityCollisionHandler>();
        onCollisionScript.PrimeProjectile(collisionHandlerFunction, pas);
    }

    //This is a bit of over-engineering but 
    private void OnCollide(Collision other, GameObject hit, ProjectileAbilityStats stats)
    {
        //Do each thing you need to do when this impacts something
        
        //Try to apply damage to thing if it has health
        //Deal OnHit damage
        // Todo: make sure the ability you make doesn't hit you as it leaves your space!
        var targetHealth = other.gameObject.GetComponent<Health>();
        Debug.Log(targetHealth);
        if(targetHealth != null)
        {
            targetHealth.TakeDamage(stats.damage);
            Debug.Log(targetHealth.currentHealth);
        }

        //Generate Explosion?
        //Apply knockback in area?
        //what else?
    }




}
