using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{

    bool isStrafe = false;
    Animator anim;
    [SerializeField] GameObject handWeapon;
    [SerializeField] GameObject backWeapon;

    [SerializeField] GameObject swordHand;

    [SerializeField] GameObject daggerHand;
    bool canAttack = true;
    float attackIndex;
    float hasarIndex;
    void Start()
    {
        anim = GetComponent<Animator>();

    }


    void Update()
    {
        anim.SetBool("iS", isStrafe);

        if (Input.GetKeyDown(KeyCode.F))
        {
            isStrafe = !isStrafe;
        }
        if (isStrafe == true)
        {
            GetComponent<chacterControls>().hareketTipi = chacterControls.MovementType.Strafe;
        }
        if (isStrafe == false)
        {
            GetComponent<chacterControls>().hareketTipi = chacterControls.MovementType.Directional;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (handWeapon.active == true)
            {
                handWeapon.SetActive(true);
                backWeapon.SetActive(true);

            }
            else if (swordHand.active == true)
            {
                StartCoroutine(ikiSaniyeBekle2());

            }


        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (handWeapon.active == true)
            {
                StartCoroutine(ikiSaniyeBekle());

            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack == true)
        {
            float hasarIndex = Random.Range(0, 3);
            attackIndex = Random.Range(0, 3);
            anim.SetFloat("attackIndex", attackIndex);
            anim.SetTrigger("Attack");


        }

    }

    IEnumerator ikiSaniyeBekle()
    {


        GetComponent<Animator>().Play("equip");
        yield return new WaitForSeconds(1f);
        daggerHand.SetActive(true);
        swordHand.SetActive(true);

        handWeapon.SetActive(false);
        backWeapon.SetActive(false);
    }
    IEnumerator ikiSaniyeBekle2()
    {


        GetComponent<Animator>().Play("equip");
        yield return new WaitForSeconds(1f);
        handWeapon.SetActive(true);
        backWeapon.SetActive(true);

        daggerHand.SetActive(false);
        swordHand.SetActive(false);
    }
    public void hasarAnim()
    {
        hasarIndex = Random.Range(0, 2);
        anim.SetFloat("hasarIndex", hasarIndex);
        anim.SetTrigger("Hasar");
    }
}
