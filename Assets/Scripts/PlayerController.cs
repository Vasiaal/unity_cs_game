using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private Animator animator; 
    private bool isGrounded = false;

    // Gravity Flip
    private bool isOnGravityPlatform = false;
    private bool canFlipGravity = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>(); 
        rb.freezeRotation = true;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 rowmove = new Vector3(-h, 0f, v);
        Vector3 move = new Vector3(h, 0f, v).normalized;
        

        if (rowmove.magnitude >= 0.1f)
        {

            Vector3 moveDir = transform.forward * move.z + transform.right * move.x;
            rb.MovePosition(rb.position + moveDir * moveSpeed * Time.deltaTime);

            animator.SetBool("isMoving", true); 
        }
        else
        {
            animator.SetBool("isMoving", false); 
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;

            animator.SetTrigger("jump"); 
        }

        // Gravity Flip
        if (Input.GetKeyDown(KeyCode.G) && isOnGravityPlatform && canFlipGravity)
        {
            StartCoroutine(FlipGravity());
        }

        // Reset on fall
        if (transform.position.y < -10f)
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator FlipGravity()
    {
        canFlipGravity = false;
        Physics.gravity *= -1;
        rb.velocity = new Vector3(rb.velocity.x, 2f, rb.velocity.z);

        GravityObject[] gravObjs = FindObjectsOfType<GravityObject>();
        foreach (GravityObject obj in gravObjs)
        {
            obj.StartFloating();
        }

        yield return new WaitForSeconds(2f);

        Physics.gravity *= -1;
        rb.velocity = new Vector3(rb.velocity.x, -2f, rb.velocity.z);
        canFlipGravity = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = true;

        if (collision.collider.CompareTag("Hazard"))
        {
            animator.SetTrigger("die"); 
            SceneManager.LoadScene(0);
        }

        if (collision.collider.CompareTag("GravityPlatform"))
            isOnGravityPlatform = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("GravityPlatform"))
            isOnGravityPlatform = false;
    }
}
