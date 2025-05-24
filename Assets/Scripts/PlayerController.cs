using UnityEngine;
using UnityEngine.InputSystem;

public class NewEmptyCSharpScript : MonoBehaviour
{
    public InputAction moveAction;
    private Rigidbody2D rb;
    public Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        moveAction.Enable();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector2 position = (Vector2)rb.position + move * 3.0f * Time.deltaTime;
        rb.MovePosition(position);
    }
}
