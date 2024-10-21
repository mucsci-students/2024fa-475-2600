using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace EthanTheHero
{
	public class PlayerMovement : MonoBehaviour
	{
		#region FIELD

		[SerializeField] private PlayerMovementData data;
		[SerializeField] private float lastOnGroundTime;
		[SerializeField] private Transform groundCheckPoint;
		[SerializeField] private Vector2 groundCheckSize = new Vector2(0.49f, 0.03f);
		[SerializeField] private LayerMask groundLayer;
		[SerializeField] private LayerMask wallLayer;
		[SerializeField] private Transform WallCheck;

		[HideInInspector] public Vector2 move;

		private Rigidbody2D myBody;
		private Animator myAnim;

		//Dash
		[HideInInspector] public bool isDashing;
		private bool canDash = true;
		private bool dashButtonPressed;

		//Jump
		[HideInInspector] public bool grounded;
		[HideInInspector] public bool isJumping;
		private bool jumpButtonPressed;

		//Wall Sliding and Wall Jump
		[HideInInspector] public bool wallJump;
		[HideInInspector] public bool wallSliding;
		private RaycastHit2D wall;
		private float jumpTime;

		//Sound Effects
		private float timer = 0f;
		[SerializeField] private AudioClip jumpSound;
		[SerializeField] public AudioClip runSound;
		[SerializeField] public float runSoundVolume;
		[SerializeField] private AudioClip dashSound;
		[SerializeField] private AudioClip wallJumpSound;
		public HealthManager script;


        #endregion

        #region MONOBEHAVIOUR
        void Awake()
		{
			myBody = GetComponent<Rigidbody2D>();
			myAnim = GetComponent<Animator>();
		}
		void Update()
		{
			if (Time.timeScale == 0 || isDashing || wallJump || myAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack01") || myAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack02") || myAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack03"))
			{
				return;
			}
			lastOnGroundTime -= Time.deltaTime;

			//Input Handler
			move.x = Input.GetAxisRaw("Horizontal");
			dashButtonPressed = Input.GetKeyDown(KeyCode.W);
			jumpButtonPressed = Input.GetButtonDown("Jump");

			jump();

			if (move.x != 0)
				CheckDirectionToFace(move.x > 0);

			if (dashButtonPressed && canDash && !wallSliding)
				StartCoroutine(dash());

			if (wallSliding && jumpButtonPressed)
				StartCoroutine(wallJumpMechanic());

		}

		void FixedUpdate()
		{
			if (Time.timeScale == 0 || isDashing || wallJump || myAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack01") || myAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack02") || myAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack03"))
				return;

			if (!wallSliding)
				run(1);
			//checks if set box overlaps with ground
			if (Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer))
			{
				lastOnGroundTime = 0.1f;
				grounded = true;
			}
			else
				grounded = false;


			WallSlidngMechanic();
		}
        #endregion

        #region RUN
        private void run(float lerpAmount)
		{
			float targetSpeed = move.x * data.runMaxSpeed;

			float accelRate;

			targetSpeed = Mathf.Lerp(myBody.velocity.x, targetSpeed, lerpAmount);

			//Calculate Acceleration and Decceleration
			if (lastOnGroundTime > 0)
				accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? data.runAccelAmount : data.runDeccelAmount;
				
			else
				accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? data.runAccelAmount * data.accelInAir : data.runDeccelAmount * data.deccelInAir;

			if (data.doConserveMomentum && Mathf.Abs(myBody.velocity.x) > Mathf.Abs(targetSpeed) && Mathf.Sign(myBody.velocity.x) == Mathf.Sign(targetSpeed) && Mathf.Abs(targetSpeed) > 0.01f && lastOnGroundTime < 0)
				accelRate = 0;

			float speedDif = targetSpeed - myBody.velocity.x;
			float movement = speedDif * accelRate;

			//Implementing run
			myBody.AddForce(movement * Vector2.right, ForceMode2D.Force);

			script.isWallSliding = false;


		}
		#endregion

		#region DASH
		private IEnumerator dash()
		{
			canDash = false;
			isDashing = true;
			float oriGrav = myBody.gravityScale;
			myBody.gravityScale = 0f;

			myBody.velocity = new Vector2(transform.localScale.x * data.dashPower, 0f);

			SoundFXManager.instance.PlaySoundFXClip(dashSound, transform, .05f);

			yield return new WaitForSeconds(data.dashingTime);
			if (move.x > 0)
			{
				myBody.velocity = new Vector2(data.runMaxSpeed, myBody.velocity.y);
			}
			else if (move.x < 0)
			{
				myBody.velocity = new Vector2(-data.runMaxSpeed, myBody.velocity.y);
			}
			myBody.gravityScale = oriGrav;

			isDashing = false;
			yield return new WaitForSeconds(data.dashingCoolDown);
			canDash = true;
		}
		#endregion

		#region JUMP
		private void jump()
		{

			if (grounded)
				isJumping = false;


			if (jumpButtonPressed && grounded)
			{
				isJumping = true;
				myBody.velocity = new Vector2(myBody.velocity.x, data.jumpHeight);
				SoundFXManager.instance.PlaySoundFXClip(jumpSound, transform, 0.25f);
			}
		}
		#endregion

		#region Wall Sliding and Wall Jump
		private void WallSlidngMechanic()
		{
			wall = Physics2D.Raycast(WallCheck.position, new Vector2(data.wallDistance, 0f), data.wallDistance, wallLayer);
			Debug.DrawRay(WallCheck.position, new Vector2(data.wallDistance, 0f), Color.red);


			if (!grounded && wall)
			{
				wallSliding = true;
				jumpTime = Time.time + data.wallJumpTime;

				script.isWallSliding = true;
			}
			else if (jumpTime < Time.time)
				wallSliding = false;
			else
				wallSliding = false;

			if (wallSliding)
			{
				myBody.velocity = new Vector2(myBody.velocity.x, Mathf.Clamp(myBody.velocity.y, -data.wallSlideSpeed, float.MaxValue));
			}

		}

		private IEnumerator wallJumpMechanic()
		{
			wallJump = true;
			if (transform.localScale.x == -1f)		
			{
				myBody.velocity = new Vector2(data.wallJumpingXPower, data.wallJumpingYPower);
				SoundFXManager.instance.PlaySoundFXClip(wallJumpSound, transform, 0.25f);
			}
			else
			{
				myBody.velocity = new Vector2(-data.wallJumpingXPower, data.wallJumpingYPower);
				SoundFXManager.instance.PlaySoundFXClip(wallJumpSound, transform, 0.25f);
			}
			yield return new WaitForSeconds(data.WallJumpTimeInSecond);
			wallJump = false;
		}
		#endregion

		#region OTHER
		private void CheckDirectionToFace(bool isMovingRight)
		{
			Vector3 tem = transform.localScale;
			if (!isMovingRight)
			{
				tem.x = -1f;
				if (grounded)
				{
					timer += Time.deltaTime;
					if(timer >= .35f)
					{
						SoundFXManager.instance.PlaySoundFXClip(runSound, transform, runSoundVolume);
						timer = 0f;
					}
				}
			}
			else
			{
				tem.x = 1f;
				if (grounded)
				{
					timer += Time.deltaTime;
					if(timer >= .35f)
					{
						SoundFXManager.instance.PlaySoundFXClip(runSound, transform, runSoundVolume);
						timer = 0f;
					}
				}
				
			}
			transform.localScale = tem;
		}
		#endregion
	}
}
