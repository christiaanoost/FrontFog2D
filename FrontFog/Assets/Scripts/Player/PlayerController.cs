using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private Camera mainCamera;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // We slaan de camera op om muisposities te berekenen
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Beweging input (bestaande code)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(moveX, moveY);

        if (movementDirection.magnitude > 1)
        {
            movementDirection = movementDirection.normalized;
        }

        // ROTATIE NAAR MUIS
        RotateTowardsMouse();
    }

    void RotateTowardsMouse()
    {
        // 1. Haal de muispositie op in wereld-coördinaten
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // 2. Bereken de richting van de player naar de muis
        Vector2 lookDirection = (Vector2)mousePosition - rb.position;

        // 3. Bereken de hoek met Atan2 (dit geeft de hoek in radialen)
        // We trekken er vaak 90 graden vanaf als je sprite standaard 'omhoog' kijkt
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        // 4. Pas de rotatie toe op de Rigidbody
        rb.rotation = angle;
    }

    void FixedUpdate()
    {
        rb.velocity = movementDirection * moveSpeed;
    }
}