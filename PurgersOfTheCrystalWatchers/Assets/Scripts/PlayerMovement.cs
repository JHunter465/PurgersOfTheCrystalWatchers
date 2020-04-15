using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    #region Declaring Variables
    #region Declaring Inspector
    [Header("Assign")]
    //Main Camera
    [SerializeField] GameObject playerCamera;
    [SerializeField] LayerMask whatIsWall;
    [SerializeField] LayerMask whatIsGround;

    [Space]
    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] float runSpeed = 1f;

    [Space]
    [Header("Turning")]
    [SerializeField] float turnSpeed;
    [SerializeField] float turnBeforeWall = .3f;

    [Space]
    [Header("Physics")]
    [SerializeField] float gravity;
    [SerializeField] float backgroundGravity;
    [SerializeField] bool airControl;
    [SerializeField] float distanceToGround = .91f;

    [Header("Slopes")]
    [SerializeField] float slopeForce;
    [SerializeField] float slopeDistance;
    [SerializeField] float slopeDegree;
    [SerializeField] float slideForce;

    [Header("Stairs...")]
    [SerializeField] float maxStepHeight;
    [SerializeField] float stepSearchDistance;

    [Space]
    [Header("Tilting")]
    //[SerializeField] float minTilt;
    //[SerializeField] float maxTilt;
    //[SerializeField] float tiltSpeed;

    //[Space]
    //[Header("Animation")]
    //[SerializeField] Animator anim;

    #endregion
    #region Declaring Private
    private Rigidbody controller;

    private List<ContactPoint> allCPs = new List<ContactPoint>();

    private Vector3 groundCP;
    private Vector3 moveDirectionRaw;
    private Vector3 moveDirection;
    private Vector3 slopeNormal;
    private Vector3 lastVelocity;

    private float turnVelocity;

    private bool wall = false;
    private bool grounded = false;
    private bool isJumping = false;
    private bool falling = false;
    private bool sliding = false;

    private RaycastHit hit;
    private RaycastHit groundHit;

    //private int speed = Animator.StringToHash("Speed");
    #endregion
    #endregion

    private void Start()
    {
        controller = GetComponent<Rigidbody>();
    }

    public void Move(float _horizontal, float _vertical, bool _jump, float _crouch, float _run)
    {
        //anim.SetFloat(speed, controller.velocity.magnitude);
        #region Stairs Pt. 1
        Vector3 _stepUpOffset = Vector3.zero;
        Vector3 _velocity = controller.velocity;
        bool _stepUp = false;
        #endregion

        #region isGrounded?
        RaycastHit _hit;
        if(Physics.Raycast(controller.transform.position, -controller.transform.up, out _hit, distanceToGround, whatIsGround))
        {
            grounded = true;
            groundCP = _hit.point;
        }
        #endregion

        //Only if the player is grounded or if airControl is enabled should we allow input
        if (grounded || airControl)
        {
            //If player stops looking around with mouse and hits forward or backward, use it as a way to control the player
            #region WhenMoving
            if (_vertical != 0 || _horizontal != 0)
            {
                #region WallCollision
                //If player walks towards a wall, orient the player away to avoid head on collision
                if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit, turnBeforeWall, whatIsWall))
                {
                    wall = true;
                    Debug.DrawRay(controller.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                }
                else
                {
                    Debug.DrawRay(controller.transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.blue);
                }

                //if player is within turnBeforeWall start turning away
                if (wall)
                {
                    //Check wich angle is smaller and rotate player that way from the wall
                    float _dotPositive = Vector3.Dot(Vector3.Cross(controller.transform.up, hit.normal), controller.transform.forward);
                    float _dotNegative = Vector3.Dot(-Vector3.Cross(controller.transform.up, hit.normal), controller.transform.forward);
                    if (_dotPositive > _dotNegative)
                    {
                        //To the right
                        float _wallRotation = Mathf.Atan2(Vector3.Cross(controller.transform.up, hit.normal).x, Vector3.Cross(controller.transform.up, hit.normal).z) * Mathf.Rad2Deg;
                        Vector3 _rotateWithTilt = TiltThis(_wallRotation);
                        controller.MoveRotation(Quaternion.Euler(_rotateWithTilt));
                        wall = false;
                    }
                    else
                    {
                        //To the left
                        float _wallRotation = Mathf.Atan2(-Vector3.Cross(controller.transform.up, hit.normal).x, -Vector3.Cross(controller.transform.up, hit.normal).z) * Mathf.Rad2Deg;
                        Vector3 _rotateWithTilt = TiltThis(_wallRotation);
                        controller.MoveRotation(Quaternion.Euler(_rotateWithTilt));
                        wall = false;
                    }
                }
                #endregion
                //Movement continues as normal
                else
                {
                    float _targetRotation = Mathf.Atan2(_horizontal, _vertical) * Mathf.Rad2Deg + playerCamera.transform.eulerAngles.y;
                    Vector3 _rotateWithTilt = TiltThis(_targetRotation);
                    controller.MoveRotation(Quaternion.Euler(_rotateWithTilt));
                }

                //Disabling the player to move faster while strafing to the side
                #region Disable MovementHack
                float _moveForward = Mathf.Abs(_vertical);
                float _moveSide = Mathf.Abs(_horizontal);

                float _move;

                if (_moveForward + _moveSide > 1f)
                {
                    _move = 1f;
                }
                else
                {
                    _move = _moveForward + _moveSide;
                }

                #endregion

                #region RUN
                if (_run != 0f)
                {
                    _move *= runSpeed;
                }
                #endregion

                moveDirectionRaw = controller.transform.forward * moveSpeed * _move * Time.fixedDeltaTime;

                #region Stairs Pt. 2
                if (grounded)
                {
                    _stepUp = FindStep(out _stepUpOffset, allCPs, groundCP, _velocity);
                }
                #endregion
            }
            #endregion

            //If player jumps we should apply an upward force and delay the gravity pulling on the player
            #region WhenJumping
            //JUMP
            #endregion

            //If player crouches we should reduce the collider size and adjust movement
            #region WhenCrouching
            //CROUCH
            #endregion

            //If airControl is true but we're not grounded than we should still apply gravity to the player when it is not grounded
            #region Falling with airControl
            if (!grounded)
            {
                falling = true;
            }
            #endregion

            //If we're grounded we can check if we're on a slope and set falling false
            #region WhenGrounded
            if (grounded)
            {
                //When we're standing on a slope we should apply a force that keeps us from sliding down or going up a slope that's too steep
                #region Slope
                if (OnSlope())
                {
                    controller.AddForce(-(groundHit.normal * slopeForce), ForceMode.Force);
                }
                #endregion

                falling = false;

                //Add background Gravity?
            }
            #endregion

            //Adding all forces together and allowing the player to move
            moveDirection = new Vector3(moveDirectionRaw.x, -backgroundGravity, moveDirectionRaw.z);
            controller.AddForce(moveDirection, ForceMode.VelocityChange);
        }
        //if the player isn't allowed to do anything and is not standing still on a surface it should apply gravity
        else
        {
            falling = true;
        }

        //When the player is falling we should apply gravity to the player even when there's no input
        #region Falling
        if (falling)
        {
            Vector3 _gravityFall = new Vector3(0, -gravity, 0);
            controller.AddForce(_gravityFall, ForceMode.Force);
        }
        #endregion

        //If we're falling and we're on a slope we should slide down the slope by applying some sideways force as well
        #region Sliding
        if (sliding)
        {
            #region Apply Sliding Force
            Vector3 _gravityFall = new Vector3(0, -gravity, 0);
            float _xForce = (1f - slopeNormal.y) * slopeNormal.x * slideForce;
            float _zForce = (1f - slopeNormal.y) * slopeNormal.z * slideForce;
            _gravityFall = new Vector3(_xForce, _gravityFall.y, _zForce);
            controller.AddForce(_gravityFall, ForceMode.Force);
            #endregion

            //We should check if the slope we're sliding down changes to a slope we can walk on and when we're down at a flat surface
            #region StillSliding?
            if (OnSlope())
            {
                sliding = false;
            }
            else
            {
                if(_hit.normal == Vector3.up)
                {
                    sliding = false;
                }
            }
            #endregion
        }
        #endregion

        #region Stairs Pt. 3
        if (_stepUp)
        {
            controller.position += _stepUpOffset;
            controller.velocity = lastVelocity;
        }
        #endregion

        //Reset all flags and vectors so player doesn't keep the same state when playerinput changes
        moveDirectionRaw = Vector3.zero;
        allCPs.Clear();
        lastVelocity = _velocity;
        groundCP = Vector3.zero;
        grounded = false;
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(controller.transform.position, Vector3.down, out groundHit, slopeDistance))
        {
            if (groundHit.normal != Vector3.up)
            {
                //If the slope we hit is too steep (slopeDegree) we are grounded but we'll slide down the slope
                #region EnableSliding
                if (Mathf.Abs(groundHit.normal.x) >= slopeDegree || Mathf.Abs(groundHit.normal.z) >= slopeDegree)
                {
                    sliding = true;
                    slopeNormal = groundHit.normal;
                    return false;
                }
                #endregion
                //If the slope is not too steep, we're indeed on a slope
                #region SetSlope
                else
                {
                    return true;
                }
                #endregion
            }
        }
        //If all else fails, there's no slope...
        return false;
    }

    //Determine what the velocity of the player is and add a tilt in the direction, this rotation is added to the rotation of the y-axis
    private Vector3 TiltThis(float _rotation)
    {
        //float _xTargetTilt = Mathf.Clamp(controller.velocity.z, minTilt, maxTilt);
        //float _zTargetTilt = Mathf.Clamp(controller.velocity.x, minTilt, maxTilt);

        //float _xTilt = Mathf.SmoothDampAngle(controller.transform.eulerAngles.x, _xTargetTilt, ref turnVelocity, tiltSpeed);
        //float _zTilt = Mathf.SmoothDampAngle(controller.transform.eulerAngles.z, _zTargetTilt, ref turnVelocity, tiltSpeed);

        float _yRotation = Mathf.SmoothDampAngle(controller.transform.eulerAngles.y, _rotation, ref turnVelocity, turnSpeed);

        Vector3 _output = new Vector3(0, _yRotation, 0);
        return _output;
    }

    private bool FindStep(out Vector3 _stepUpOffset, List<ContactPoint> _allCPs, Vector3 _groundCP, Vector3 _currVelocity)
    {
        _stepUpOffset = Vector3.zero;

        foreach (ContactPoint _cp in _allCPs)
        {
            if(FindStepUp(out _stepUpOffset, _cp, _groundCP))
            {
                return true;
            }
        }
        return false;
    }

    private bool FindStepUp(out Vector3 _stepUpOffset, ContactPoint _stepTestCP, Vector3 _groundCP)
    {
        _stepUpOffset = Vector3.zero;
        Collider _stepCol = _stepTestCP.otherCollider;

        if(Mathf.Abs(_stepTestCP.normal.y) >= 0.01f)
        {

            return false;
        }
        else if(!(_stepTestCP.point.y - _groundCP.y < maxStepHeight))
        {
            return false;
        }
        else
        {
            RaycastHit _hit;
            float _stepHeight = _groundCP.y + maxStepHeight + 0.0001f;
            Vector3 _stepTestInvDir = new Vector3(-_stepTestCP.normal.x, 0, -_stepTestCP.normal.z).normalized;
            Vector3 _origin = new Vector3(_stepTestCP.point.x, _stepHeight, _stepTestCP.point.z) + (_stepTestInvDir * stepSearchDistance);
            Vector3 _direction = Vector3.down;
            if(!(_stepCol.Raycast(new Ray(_origin, _direction), out _hit, maxStepHeight)))
            {
                return false;
            }
            else
            {
                Vector3 _stepUpPoint = new Vector3(_stepTestCP.point.x, _hit.point.y + 0.0001f, _stepTestCP.point.z) + (_stepTestInvDir * stepSearchDistance);
                Vector3 _stepUpPointOffset = _stepUpPoint - new Vector3(_stepTestCP.point.x, _groundCP.y, _stepTestCP.point.z);

                _stepUpOffset = _stepUpPointOffset;
                return true;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        allCPs.AddRange(col.contacts);
    }
    void OnCollisionStay(Collision col)
    {
        allCPs.AddRange(col.contacts);
    }
}
