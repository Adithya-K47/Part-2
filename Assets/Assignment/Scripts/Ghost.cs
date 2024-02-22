using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ghost : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;
    Vector2 dest;
    Vector2 mov;
    public float speed = 3;
    public float hp;
    float maxHP = 5;
    public bool Down;
    public HealthBar hb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = maxHP;
        Down = false;

    }
    private void FixedUpdate()
    {
        if (Down) return;
        
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
        if (Down) return;
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        gameObject.SendMessage("HBval", hp, SendMessageOptions.DontRequireReceiver);
        animator.SetFloat("Movement", mov.magnitude);
    }


    public void TakeDamage(float damage)
    {
        hp -= damage;
        hp = Mathf.Clamp(hp, 0, maxHP);
        if (hp <= 0)
        {
            Down = true;
            animator.SetTrigger("Death");
        }
        else
        {
            Down = false;
            animator.SetTrigger("TakeDamage");
        }
    }

    public void Respawn()
    {
        if(Down == true)
        {
            hp = 5;
            Down = false;
            animator.SetTrigger("TakeDamage");
        }
        
    }
}
