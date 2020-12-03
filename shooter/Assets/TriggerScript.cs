using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerScript : MonoBehaviour
{
    public float aoeDamage;

    void OnParticleTrigger()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();

        // particles
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

        // get
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        // iterate
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            p.remainingLifetime = 0;
            FindObjectOfType<PlayerHealth>().ReceiveDamage(aoeDamage);
            enter[i] = p;
        }
        //set
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    }
}