using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Animator animator;
    private BoxCollider2D coll;

    public float speed = 100;

	// Use this for initialization
	void Start () {
        animator = GetComponentInChildren<Animator>();
        coll = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        
        

        if (vertical > 0)
        {
            //if (!coll.IsTouchingLayers(LayerMask.GetMask("Environment")))
            //{
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * vertical * Time.deltaTime, transform.position.z);
            //}
            animator.SetInteger("Direction", 2);
            animator.SetBool("IsMoving", true);
        }
        if (vertical < 0)
        {
            //if (!coll.IsTouchingLayers(LayerMask.GetMask("Environment")))
            //{
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * vertical * Time.deltaTime, transform.position.z);
            //}
            animator.SetInteger("Direction", 0);
            animator.SetBool("IsMoving", true);
        }
        if (horizontal < 0)
        {
            //if (!coll.IsTouchingLayers(LayerMask.GetMask("Environment")))
            //{
                transform.position = new Vector3(transform.position.x + speed * horizontal * Time.deltaTime, transform.position.y, transform.position.z);
            //}
            animator.SetInteger("Direction", 1);
            animator.SetBool("IsMoving", true);
        }
        if (horizontal > 0)
        {
            //if (!coll.IsTouchingLayers(LayerMask.GetMask("Environment")))
            //{
                transform.position = new Vector3(transform.position.x + speed * horizontal * Time.deltaTime, transform.position.y, transform.position.z);
            //}
            animator.SetInteger("Direction", 3);
            animator.SetBool("IsMoving", true);
        }
        if(horizontal + vertical == 0)
        {
            animator.SetBool("IsMoving", false);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    foreach(ContactPoint2D c in collision.contacts)
    //    {
    //        Vector3 cv3 = new Vector3(c.point.x, c.point.y, transform.position.z);
    //        float dist = 50 - Vector3.Distance(transform.position, cv3);
    //        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(c.normal.x * dist, c.normal.y * dist, 0), .8f);
    //    }
    //}
}
