using UnityEngine;

public class AntMovement : MonoBehaviour
{
    public string targetTag = "Candy"; // Tag of the object the ant should follow
    public float moveSpeed = 2f; // Speed at which the ant moves towards the target
    private Transform target; // Reference to the target object

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Find the GameObject with the specified tag
        GameObject targetObject = GameObject.FindGameObjectWithTag(targetTag);

        // Ensure a valid target object with the specified tag exists
        if (targetObject != null)
        {
            target = targetObject.transform;
        }
        else
        {
            Debug.LogError("No object found with the specified tag.");
        }
    }

    private void Update()
    {
        if (target != null)
        {
            MoveTowardsTarget();
            FaceTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();

        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
    }

    private void FaceTarget()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90f; // Adjust for sprite orientation if needed
    }
}
