using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Video reference for player movement: https://www.youtube.com/watch?v=4HpC--2iowE
    // Video reference for player jumping: https://www.youtube.com/watch?v=_QajrabyTJc

    // Reference to Character Controller
    public CharacterController controller;
    public Transform cam;

    Vector3 velocity;
    bool isGrounded;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float smoothTurn = 0.1f;
    public float smoothTurnVelocity;

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothTurnVelocity, smoothTurn);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

    // Video reference for UI and Score updating: https://www.youtube.com/watch?v=NwJthsBdmcA

    int score = 0;
    public GameObject winText;
    public int winScore;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            score++;
            scoreText.text = $"Score: {score}";

            if (score >= winScore)
            {
                winText.SetActive(true);
            }
        }
    }
}
