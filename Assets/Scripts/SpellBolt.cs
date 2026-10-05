using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpellBolt : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifetime = 3f;
    private Rigidbody2D rb;
    private float remainingTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        remainingTime = lifetime;
        rb.linearVelocity = (Vector2)transform.right * speed;
    }

    private void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        rb.linearVelocity = Vector2.zero;
    }
}
