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
    
    public override void Initialize(GameObject obj)
    {
        //set values on whatever is going be handling putting the projectile into the world??    
        launcher = obj.GetComponent<ProjectileAbilityHandler>();
        launcher.projectileForce = projectileForce;
        launcher.projectile = projectileToSpawn;
        
    }

    public override void Activate()
    {
        Debug.Log($"Pew Pew! Projectile Ability with name: {this.abilityName} was triggered!");
        //This should call the launcher.fire() or something, or maybe just handle everything here - I don't even know why we need that in particular
        launcher.Launch();
        this.effect.Play();
    }
}