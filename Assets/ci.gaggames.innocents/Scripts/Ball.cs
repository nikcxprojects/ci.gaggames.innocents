using UnityEngine;

public class Ball : MonoBehaviour
{
    private Camera _camera;
    private Vector2 Velocity { get; set; }
    private Rigidbody2D Rigidbody { get; set; }
    private LineRenderer LineRenderer { get; set; }


    [SerializeField] float launchForce;
    [SerializeField] int numOfDots;
    [SerializeField] float offset;

    private Vector3[] Positions { get; set; }

    private void Awake()
    {
        _camera = Camera.main;
        Rigidbody = GetComponent<Rigidbody2D>();
        LineRenderer = FindObjectOfType<LineRenderer>();

        Positions = new Vector3[numOfDots];
    }

    private void Start()
    {
        Rigidbody.isKinematic = true;
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

            Physics2D.gravity = new Vector2(Velocity.x > 0 ? -2.8f : 2.8f, 0.5f);

            for (int i = 0; i < Positions.Length; i++)
            {
                Positions[i] = DotPositionByTime(i * offset);
            }

            LineRenderer.positionCount = Positions.Length;
            LineRenderer.SetPositions(Positions);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.isKinematic = false;
            Rigidbody.AddForce(Velocity * launchForce, ForceMode2D.Impulse);
        }
    }

    private Vector2 DotPositionByTime(float t)
    {
        return (Vector2)transform.position + (Velocity * launchForce * t) + 0.5f * Physics2D.gravity * Mathf.Pow(t, 2);
    }
}