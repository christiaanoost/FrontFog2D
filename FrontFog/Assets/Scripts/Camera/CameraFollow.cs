using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Sleep je Player hierin
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -10); // Zorg dat de camera op -10 blijft staan

    void LateUpdate()
    {
        // We berekenen de gewenste positie (alleen de X en Y van de speler)
        Vector3 desiredPosition = target.position + offset;
        
        // We maken de beweging vloeiend (optioneel, maar mooier)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Pas de positie aan, maar behoud de eigen rotatie van de camera
        transform.position = smoothedPosition;
    }
}