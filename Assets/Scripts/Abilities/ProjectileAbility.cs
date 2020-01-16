using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Projectile Ability")]
public class ProjectileAbility : AbilityBase
{

    public float projectileForce = 500f;
    public GameObject projectileToSpawn;
    public ProjectileAbilityHandler launcher;
    //public Animator / Animation castAnimation;
    //Would only cast the ability after the cast time

    public Vector3 launchOffSet = new Vector3(0, 0, 0);

    private ProjectileAbilityStats projectileStats;
    public override void Initialize(GameObject obj)
    {
        //set values on whatever is going be handling putting the projectile into the world??    
        launcher = obj.GetComponent<ProjectileAbilityHandler>();
        launcher.projectileForce = projectileForce;
        launcher.projectile = projectileToSpawn;
        Debug.Log(this.abilityName + " was just intitialized!");
    }

    public override void Activate()
    {
        Debug.Log($"{this.abilityName} was triggered!");       
        
        launcher.Launch(this);
        if(this.effect != null)
        {
            this.effect.Play();
        }
    }
}