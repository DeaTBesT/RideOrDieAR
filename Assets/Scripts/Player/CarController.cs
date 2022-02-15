using SimpleInputNamespace;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private Transform ground;

    [SerializeField] private Joystick m_joystick;

    private Rigidbody m_rigidbody;

    [SerializeField] private Wheels wheels;

    [System.Serializable]
    public struct Wheels
    {
        public WheelCollider wheelLF;
        public WheelCollider wheelRF;
        public WheelCollider wheelLB;
        public WheelCollider wheelRB;
    }

    public bool IsMove { get; private set; }

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_joystick = GameManager.Instance.GetJoystick;
    }

    private void Update()
    {
        GroundMove();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float inputX = m_joystick.Value.x;
        float inputY = m_joystick.Value.y;

        //Move
        float move = Mathf.Abs(inputX) + Mathf.Abs(inputY);

        wheels.wheelLF.motorTorque = move * speedMove;
        wheels.wheelRF.motorTorque = move * speedMove;

        float currentSteer = inputX * maxSteerAngle;

        wheels.wheelLF.steerAngle = currentSteer;
        wheels.wheelRF.steerAngle = currentSteer;

        IsMove = move == 1 ? true : false;
    }

    private void GroundMove()
    {
        ground.transform.position = new Vector3(transform.position.x, ground.transform.position.y, transform.position.z);
    }
}
