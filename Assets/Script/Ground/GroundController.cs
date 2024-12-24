using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public GameObject[] blocks;

    // Start is called before the first frame update
    void Start()
    {
        blocks = new GameObject[this.gameObject.transform.childCount];
        for (int i = 0; i < blocks.Length; i++) {
            blocks[i] = this.gameObject.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            ChangeGround();
        }
    }

    public void ChangeGround() {
        for (int i = 0; i < blocks.Length; i++) {
            blocks[i].SetActive(true);
        }
        for (int i = 1; i <= 5; i++) {
            blocks[Random.Range(0, blocks.Length - 1)].SetActive(false);
        }
    }
}
