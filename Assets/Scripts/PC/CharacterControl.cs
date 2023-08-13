using System.Collections.Generic;
using UnityEngine;


    public class CharacterControl : MonoBehaviour
    {

        [SerializeField] private float m_moveSpeed = 2;
        [SerializeField] private float m_jumpForce = 4;
        [SerializeField] private float m_turnSpeed = 10;

        [SerializeField] private Animator m_animator = null;
        [SerializeField] private Rigidbody m_rigidBody;

        private int color = 0;
        private GameObject spew = null;
        float turnSmoothVelocity;
        public Transform cam;

        private bool m_wasGrounded;
        private Vector3 m_currentDirection = Vector3.zero;

        private float m_jumpTimeStamp = 0;
        private float m_minJumpInterval = 0.25f;
        private bool m_jumpInput = false;

        private bool m_isGrounded;

        private List<Collider> m_collisions = new List<Collider>();

        private void Awake()
        {
            if (!m_animator) { gameObject.GetComponent<Animator>(); }

        }

        private void OnCollisionEnter(Collision collision)
        {
            ContactPoint[] contactPoints = collision.contacts;
            for (int i = 0; i < contactPoints.Length; i++)
            {
                if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
                {
                    if (!m_collisions.Contains(collision.collider))
                    {
                        m_collisions.Add(collision.collider);
                    }
                    m_isGrounded = true;
                }
            }
            if (collision.gameObject.CompareTag("pod"))
            {
                BulbController bc = collision.gameObject.GetComponent<BulbData>().bulb;
                int c = collision.gameObject.GetComponent<BulbData>().b;
                Debug.Log("New Player Color,");
                Debug.Log(c);
                collision.gameObject.GetComponent<BulbData>().changeColor(color);
                color = c;
                Transform[] children = GetComponentsInChildren<Transform>();
                foreach (Transform child in children)
                {
                    if (child.CompareTag("spew"))
                    {
                        Destroy(child.gameObject);
                    }
                }
                spew = Instantiate(bc.getPlayerSpew(color), this.transform);
            }
    }

        private void OnCollisionStay(Collision collision)
        {
            ContactPoint[] contactPoints = collision.contacts;
            bool validSurfaceNormal = false;
            for (int i = 0; i < contactPoints.Length; i++)
            {
                if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
                {
                    validSurfaceNormal = true; break;
                }
            }

            if (validSurfaceNormal)
            {
                m_isGrounded = true;
                if (!m_collisions.Contains(collision.collider))
                {
                    m_collisions.Add(collision.collider);
                }
            }
            else
            {
                if (m_collisions.Contains(collision.collider))
                {
                    m_collisions.Remove(collision.collider);
                }
                if (m_collisions.Count == 0) { m_isGrounded = false; }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }

        private void Update()
        {
            if (!m_jumpInput && Input.GetKey(KeyCode.Space))
            {
                m_jumpInput = true;
            }
        }


        private void FixedUpdate()
        {
            m_animator.SetBool("Grounded", m_isGrounded);

            DirectUpdate();
        

            m_wasGrounded = m_isGrounded;
            m_jumpInput = false;
        }

        

        private void DirectUpdate()
        {
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");
            Vector3 direction = new Vector3(h, 0f, v).normalized;

            if (direction != Vector3.zero)
            {
                Vector3 moveAmount = direction * m_moveSpeed * Time.deltaTime;
                transform.Translate(moveAmount);
                m_animator.SetFloat("MoveSpeed", moveAmount.magnitude);
            }

            JumpingAndLanding();
        }

        private void JumpingAndLanding()
        {
            bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

            if (jumpCooldownOver && m_isGrounded && m_jumpInput)
            {
                m_jumpTimeStamp = Time.time;
                m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            }

            if (!m_wasGrounded && m_isGrounded)
            {
                m_animator.SetTrigger("Land");
            }

            if (!m_isGrounded && m_wasGrounded)
            {
                m_animator.SetTrigger("Jump");
            }
        }
    }
