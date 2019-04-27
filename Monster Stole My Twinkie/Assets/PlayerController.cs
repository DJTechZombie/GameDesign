using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed =7.5f;
    [SerializeField]
    private float turnSpeed =150f;

    private CharacterController characterController;
    private FireWeapon fireWeapon;
    private Animator anim;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        fireWeapon = GetComponent<FireWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMove, 0, verticalMove);

        anim.SetFloat("Speed", verticalMove);

        transform.Rotate(Vector3.up, horizontalMove * turnSpeed * Time.deltaTime);
        if(verticalMove != 0)
        {
            characterController.SimpleMove(transform.forward * moveSpeed * verticalMove);
        }
        
        if(Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("isShooting", true);
        }

        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("isShooting", false);
        }
        

    }

    private void Shoot()
    {
        fireWeapon.ShootWeapon();
    }
}
