using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionCheck : MonoBehaviour
{
    public ContactFilter2D castFilter;

    public float groundDistance = 0.05f;
    public float wallDistance = 0.2f;
    public float ceilingDistance = 0.05f;

    RaycastHit2D[] goundHits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];

    BoxCollider2D touchingCol;
    Animator anim;

    private bool _isGrouded = true;

    public bool IsGrounded
    {
        get { return _isGrouded; }
        private set
        {
            _isGrouded = value;
            anim.SetBool(AnimationStrings.IsGrounded, _isGrouded);
        }
    }

    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    private bool _isOnWall = false;
    public bool IsOnWall
    {
        get { return _isOnWall; }
        private set
        {
            _isOnWall = value;
        }
    }

    private bool _isOnCeiling = false;
    public bool IsOnCeiling
    {
        get { return _isOnCeiling; }
        private set
        {
            _isOnCeiling = value;
        }
    }

    private void Awake()
    {
        touchingCol = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        IsGrounded = touchingCol.Cast(Vector2.down, castFilter, goundHits, groundDistance) > 0;
        IsOnWall = touchingCol.Cast(wallCheckDirection, castFilter, wallHits, wallDistance) > 0;
        IsOnCeiling = touchingCol.Cast(Vector2.up, castFilter, ceilingHits, ceilingDistance) > 0;
    }
}
