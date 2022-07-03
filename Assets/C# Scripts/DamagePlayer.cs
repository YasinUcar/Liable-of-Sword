using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

   
    int damage = 10;
    [SerializeField] GameObject hitParticle;

    void Start()
    {
        
    }

    void Update()
    {
        var PlayerHBDeneme = GetComponent<PlayerHBDeneme>();
        PlayerHBDeneme.DeathOfCharacter();
         hitParticle.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        var PlayerHBDeneme = GetComponent<PlayerHBDeneme>();
        if (other.tag == "EnemyDagger")
        {
            hitParticle.GetComponent<ParticleSystem>().Play();
            PlayerHBDeneme.TakeDamage(10);

        }
        hitParticle.SetActive(true);
    }


}
