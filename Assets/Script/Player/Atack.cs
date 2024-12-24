using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    public WeaponController controller;
    public Camera cam;
    float attackMeleeDistance = 2f;
    float attackRangeDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            controller.IsAttack = true;
        }
        if (Input.GetMouseButton(0)) {
            if (controller.WeaponType == 0) {
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, attackMeleeDistance)) {
                    if (hit.transform.tag == "Enemy") {
                        Destroy(hit.transform.gameObject);
                    }
                }
            } else {
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, attackRangeDistance)) {
                    if (hit.transform.tag == "Enemy") {
                        Destroy(hit.transform.gameObject);
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0)) {
            controller.IsAttack = false;
        }
    }
}
