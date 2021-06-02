using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 2f;
    public float SprintSpeed = 2f;
    
    private Rigidbody RigB;
    private float HorizontalAxis;
    private float VerticalAxis;
    private Transform _cacheTransform;

    // Start is called before the first frame update
    void Awake()
    {
        RigB = GetComponent<Rigidbody>();
        _cacheTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {   
        UpdateAxies();
        RunToggle();
        MovementHandler();
    }

    private void MovementHandler()
    {
        Vector3 moveInput = new Vector3(HorizontalAxis, 0f, VerticalAxis);
        Vector3 worldSpaceInput = transform.TransformVector(moveInput);

        Vector3 delta = Speed * Time.deltaTime * worldSpaceInput;
        _cacheTransform.position = _cacheTransform.position + delta;
    }

    private void RunToggle()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) Speed += SprintSpeed;
        if (Input.GetKeyUp(KeyCode.LeftShift)) Speed -= SprintSpeed;
    }

    private void UpdateAxies()
    {
        VerticalAxis = Input.GetAxis("Vertical");
        HorizontalAxis = Input.GetAxis("Horizontal");
    }
}
