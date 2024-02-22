using UnityEngine.UI;
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
    public HealthBar hb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = maxHP;

    }
    private void FixedUpdate()
    {
        mov = dest - (Vector2)transform.position;
        Debug.Log(Equals(dest, mov));
        if (mov.magnitude < 0.1)
        {
            mov = Vector2.zero;
        }
        rb.MovePosition(rb.position + mov.normalized * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        gameObject.SendMessage("HBval", hp, SendMessageOptions.DontRequireReceiver);
    }


    public void TakeDamage(float damage)
    {
       
    }
}
