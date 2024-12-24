using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    Animator anim;
    public bool IsAttack = false;
    public int WeaponType = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("IsAttack", IsAttack);
        if (!IsAttack && Input.GetMouseButtonDown(1)) {
            WeaponType = (WeaponType + 1) % 2;
            anim.SetInteger("WeaponType", WeaponType);
        }
    }
}
