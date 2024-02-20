using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ghost : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Vector2 dest;
    Vector2 mov;
    public float speed = 3;
    public float hp;
    float maxHP = 5;
    public bool isDown;
    public HealthBar hb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isDown = false;
        if (hp <= 0)
        {
            isDown = true;
            animator.SetTrigger("Death");
        }
    }

    private void FixedUpdate()
    {
        if (isDown) return;
        mov = dest - (Vector2)transform.position;
        if (mov.magnitude < 0.1)
        {
            mov = Vector2.zero;
        }
        rb.MovePosition(rb.position + mov.normalized * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDown) return;
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");
        }
        animator.SetFloat("Movement", mov.magnitude);
        gameObject.SendMessage("HealthBarvalue", hp, SendMessageOptions.DontRequireReceiver);
    }
}
