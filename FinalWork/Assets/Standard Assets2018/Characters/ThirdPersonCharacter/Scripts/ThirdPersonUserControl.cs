using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // 引用UI命名空间
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        private Rigidbody m_Rigidbody;            // Reference to the character's Rigidbody

        public Text speedText;                    // Reference to the Text component
        private float originalMoveSpeed;

        public float mouseSensitivity = 100f;     // Mouse sensitivity for camera movement
        private float xRotation = 0f;             // Current camera rotation around the X axis

        private void Start()
        {
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
            m_Rigidbody = GetComponent<Rigidbody>();

            // Find the Text component in the scene
            speedText = GameObject.Find("SpeedText").GetComponent<Text>();

            // Lock cursor to the center of the screen
            Cursor.lockState = CursorLockMode.Locked;
        }


        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            // Handle camera rotation with mouse input
            float mouseX = CrossPlatformInputManager.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = CrossPlatformInputManager.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -180f, 180f); // Limit the vertical rotation

            m_Cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX); // Rotate the character around the Y axis
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            // read inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);

            // calculate move direction to pass to character
            
            if (m_Cam != null)
            {
              // calculate camera relative direction to move:
              m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
              m_Move = v*m_CamForward + h*m_Cam.right;
             }
             else
             {
              // we use world-relative directions in the case of no main camera
               m_Move = v*Vector3.forward + h*Vector3.right;
             }
#if !MOBILE_INPUT
            // walk speed multiplier
            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;

            // Update the speedText with the current speed
            float speed = m_Rigidbody.velocity.magnitude;
            speedText.text = "速度: " + speed.ToString("F2");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("aid"))
            {
                m_Character.Accelerate(1.5f, 4f); // 加速到原始速度的1.5倍，持续4秒
                Destroy(other.gameObject); // 销毁碰撞的"aid"物体
            }
            else if (other.CompareTag("mud_road"))
            {
                originalMoveSpeed = m_Character.MoveSpeedMultiplier; // 记录原始移动速度
                m_Character.MoveSpeedMultiplier *= 0.5f; // 在泥路上速度减半
            }
            else if (other.CompareTag("finish"))
            {
                // 加载目标场景
                SceneManager.LoadScene("end_scene");
            }
            else if(other.CompareTag("zombie"))
            {
                // 加载目标场景
                SceneManager.LoadScene("lose_menu");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("mud_road"))
            {
                m_Character.MoveSpeedMultiplier = originalMoveSpeed; // 离开泥路后恢复原始速度

            }
        }
    }
}
