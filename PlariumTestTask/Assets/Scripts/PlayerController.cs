using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float interactionRadius = 3f;
    private Rigidbody2D _body;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            movement.x = horizontalInput * speed;
            movement.y = verticalInput * speed;
            movement = Vector2.ClampMagnitude(movement, speed);
            _body.velocity = movement;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius);

            foreach (Collider2D hitCollider in hitColliders)
            {
                hitCollider.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
