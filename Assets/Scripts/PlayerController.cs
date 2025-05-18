using UnityEngine;

public class NewEmptyCSharpScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x = position.x + 0.05F;
        transform.position = position;
    }
    
}
