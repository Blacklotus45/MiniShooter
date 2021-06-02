using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 2f;
    public float SprintSpeed = 2f;
    
    private Rigidbody RigB;
    private float HorizontalAxis;
    private float VerticalAxis;

    // Start is called before the first frame update
    void Awake()
    {
        RigB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        VerticalAxis = Input.GetAxis("Vertical");
        HorizontalAxis = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift)) Speed += SprintSpeed;
        if (Input.GetKeyUp(KeyCode.LeftShift)) Speed -= SprintSpeed;
    }

    private void FixedUpdate()
    {
        Vector3 delta = new Vector3(HorizontalAxis, 0f, VerticalAxis);
        delta = Speed * Time.fixedDeltaTime * delta;
        RigB.MovePosition(RigB.position + delta);
    }
}
