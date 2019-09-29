using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private float moveSpeed = 5f;

    private Vector2 movement;

    public bool itemAvailable;
    public GameObject item;
    public bool isHoldingItem;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHoldingItem)
            {
                item.transform.SetParent(null);
                isHoldingItem = false;
            } else if (itemAvailable)
            {
                item.transform.SetParent(gameObject.transform);
                item.transform.localPosition = new Vector3(0, 0.5f, 0);
                isHoldingItem = true;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void SetItem(GameObject go)
    {
        item = go;
    }
}
