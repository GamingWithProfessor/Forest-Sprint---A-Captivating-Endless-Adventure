using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody PlayerRb;
    public float gravityModifier;
    public float jumpForce = 500;
    public bool gameOver;
    public bool IsOnGround;
    private Animator PlayerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        PlayerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround && gameOver == false)
        {
            PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            PlayerAnim.SetTrigger("Jump_trig");
            IsOnGround = false;
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
            dirtParticle.Play();
        }        

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            PlayerAnim.SetBool("Death_b", true);
            PlayerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
        }
    }
}
