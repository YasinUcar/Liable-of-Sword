using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    public int playerHealth = 30;
    int damage = 10;
    void Start()
    {
        Debug.Log(playerHealth);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyDagger")
        {
           Debug.Log("enemydagger touched");
        }
    }


}
