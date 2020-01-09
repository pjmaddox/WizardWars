using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityBase : ScriptableObject
{
    public string abilityName = "New Ability";
    public float baseCooldown = 1f;
    public float castTime = 1f;
    public float targetKnockbackForce = 0f;
    public float casterKnockbackForce = 0f;
    public int maxStacks = 1;
    public float damage = 0f;

    public Sprite abilitySprite;
    public ParticleSystem effect;
    public AudioClip abilitySound;


    public abstract void Initialize(GameObject obj);
    public abstract void Activate();
}
