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
    
      

    }

    public void OnTriggerEnter(Collider other)
    {
        var PlayerHBDeneme = GetComponent<PlayerHBDeneme>();
        if (other.tag == "EnemyDagger")
        {

          
              Instantiate( hitParticle, new Vector3(transform.position.x,transform.position.y+1,transform.position.z), transform.rotation ) ;
              hitParticle.GetComponent<ParticleSystem>().Play();
            PlayerHBDeneme.TakeDamage(10);

        }

    }


}
