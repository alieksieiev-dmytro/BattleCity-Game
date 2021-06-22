using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float interactionRadius = 3f;
    private Rigidbody2D _body;

    [SerializeField] private GameObject bulletPrefab;
    private GameObject _bullet;

    [SerializeField] private GameObject playerBase;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        transform.position = playerBase.transform.position;
        transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        movement.x = horizontalInput;
        movement.y = verticalInput;

        movement = Vector2.ClampMagnitude(movement, speed);
        _body.MovePosition(_body.position + movement * speed * Time.deltaTime);

        if (movement != Vector2.zero)
        {
            transform.rotation =
                Quaternion.LookRotation(Vector3.back, movement);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius);

            foreach (Collider2D hitCollider in hitColliders)
            {
                hitCollider.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            _bullet = Instantiate(bulletPrefab) as GameObject;
            _bullet.transform.position =
                transform.TransformPoint(0.15f, 0.75f, 1.5f);
            _bullet.transform.rotation = transform.rotation;

            _bullet = Instantiate(bulletPrefab) as GameObject;
            _bullet.transform.position =
                transform.TransformPoint(-0.15f, 0.75f, 1.5f);
            _bullet.transform.rotation = transform.rotation;
        }
    }
}
