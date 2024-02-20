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
        hp = maxHP;
        
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
        animator.SetFloat("Movement", mov.magnitude);
        gameObject.SendMessage("HBval", hp, SendMessageOptions.DontRequireReceiver);
    }


    public void TakeDamage(float damage)
    {
        hp -= damage;
        hp = Mathf.Clamp(hp, 0, maxHP);
        if (hp <= 0)
        {
            isDown = true;
            animator.SetTrigger("Death");
        }
        else
        {
            isDown = false;
            animator.SetTrigger("TakeDamage");
        }
    }
}
