using UnityEngine;
using UnityEngine.InputSystem;

public class NewEmptyCSharpScript : MonoBehaviour
{
    public InputAction moveAction;

    // Start is called before the first frame update
    void Start()
    {
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 10;
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        Debug.Log(move);
        Vector2 position = (Vector2)transform.position + move * 3.0F * Time.deltaTime;
        transform.position = position;
    }
}
