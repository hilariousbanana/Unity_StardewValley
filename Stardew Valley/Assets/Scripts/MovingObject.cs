using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Sprites;
using UnityEngine;
using UnityEngine.XR;

public class MovingObject : MonoBehaviour
{
    public float speed = 0.03f;
    public float runSpeed;
    private float applyRunSpeed;

    private Vector3 vector;

    private Animator animator;
    private BoxCollider2D boxCollider;
    public LayerMask layerMask;

    public bool canWalk = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            applyRunSpeed = runSpeed;
        }
        else
            applyRunSpeed = 0;

        animator.SetFloat("DirX", vector.x);
        animator.SetFloat("DirY", vector.y);

        animator.SetBool("Walking", true);
        vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (vector.x != 0)
                vector.y = 0;

            animator.SetFloat("DirX", vector.x);
            animator.SetFloat("DirY", vector.y);

            RaycastHit2D hit;
            Vector2 start = transform.position;
            Vector2 end = start + new Vector2(vector.x * speed, vector.y * speed);

            boxCollider.enabled = false;
            hit = Physics2D.Linecast(start, end, layerMask);
            boxCollider.enabled = true;

            if (hit.transform != null)
            {
                animator.SetBool("Walking", false);
                canWalk = false;
            }
            else
                animator.SetBool("Walking", true);

            if (vector.x != 0)
            {
                transform.Translate(vector.x * (speed + applyRunSpeed), 0, 0);
            }
            else if (vector.y != 0)
            {
                transform.Translate(0, vector.y * (speed + applyRunSpeed), 0);
            }
        }
        else
        {
            animator.SetBool("Walking", false);
            canWalk = false;
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(WalkControlCoroutine());
    }

    IEnumerator WalkControlCoroutine()
    {
        speed = 0;
        yield return new WaitForSeconds(1.0f);
        speed = 0.008f;
    }
}
