using UnityEngine;

public class Ball : MonoBehaviour
{
    private Camera _camera;
    private Vector2 Velocity { get; set; }
    private Rigidbody2D Rigidbody { get; set; }

    [SerializeField] float launchForce;

    private void Awake()
    {
        _camera = Camera.main;
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Time.timeScale < 1)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 toInput = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            toInput.Normalize();

            toInput.x = Mathf.Clamp(toInput.x, -0.3f, 0.3f);
            toInput.y = Mathf.Clamp(toInput.y, 0.2f, 1);

            Velocity = toInput;
            transform.up = toInput;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Physics2D.gravity = new Vector2(Velocity.x > 0 ? -9.8f : 9.8f, 0);
            Rigidbody.AddForce(transform.up * launchForce, ForceMode2D.Impulse);
        }
    }
}
