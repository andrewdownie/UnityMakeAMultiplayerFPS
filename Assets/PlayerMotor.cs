using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    //Setter for the velocity variable
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //Setter for the rotation variable
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    //Setter for the camera rotation variable
    public void CameraRotate(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    //Run every physics iteration
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    //Perform movement based on velocity variable
    private void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }


    //Perform rotation
    private void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }


}
