using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHBDeneme : MonoBehaviour
{

   int maxHealth = 600;
    public int currentHealth;
    Animator anim;
    float hasarIndex;
    public AudioSource dieSound;
    public AudioClip dieClip;

    public CanvasHealthBarCode HealthBar;
    public bool olduMu;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();
        olduMu = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void TakeDamage(int damage)
    {

        var weaponController = GetComponent<weaponController>();
        weaponController.hasarAnim();


        currentHealth -= damage;



        HealthBar.SetHealth(currentHealth);
    }

    public void DeathOfCharacter()
    {
        if (currentHealth <= 0)
        {
            if (dieSound.isPlaying != true)
            {
                dieSound.PlayOneShot(dieClip);
            }
            StartCoroutine(ikiSaniyeBekle());
        }
    }
    IEnumerator ikiSaniyeBekle()
    {

        olduMu = true;
        var weaponController = GetComponent<weaponController>();

        weaponController.dieAnim();

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);




    }
}
