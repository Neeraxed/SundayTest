using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick floatingJoystick;
    [SerializeField] private Animator animatorController;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    private Rigidbody rigidbody;
    private Vector3 moveVector;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        moveVector = Vector3.zero;
        moveVector.x = floatingJoystick.Horizontal * moveSpeed * Time.deltaTime;
        moveVector.z = floatingJoystick.Vertical * moveSpeed * Time.deltaTime;

        if (floatingJoystick.Horizontal != 0 || floatingJoystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, moveVector, rotationSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);

            animatorController.SetFloat("moveX", floatingJoystick.Horizontal);
            animatorController.SetFloat("moveZ", floatingJoystick.Vertical);

        }

        if (floatingJoystick.Horizontal == 0 || floatingJoystick.Vertical == 0)
        {
            animatorController.SetFloat("moveX", 0);
            animatorController.SetFloat("moveZ", 0);
        }

        rigidbody.MovePosition(rigidbody.position + moveVector);
    }

    public void Aim()
    {
        if (animatorController.GetFloat("aim") != 1)
            animatorController.SetFloat("aim", 1);
        else
            animatorController.SetFloat("aim", 0);
    }

    public void Jump()
    {
        rigidbody.AddForce(Vector3.up * 4, ForceMode.Impulse);
    }
}
