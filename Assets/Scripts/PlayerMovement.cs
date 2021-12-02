using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float       horizontalSpeed;
    [SerializeField] private float       verticalSpeed;
    private                  Rigidbody2D _body;
    private                  Animator    _animator;
    private                  bool        _grounded;
    private static readonly  int         Jumping = Animator.StringToHash("jumping");
    private static readonly  int         Walking = Animator.StringToHash("walking");

    private void Awake()
    {
        this._body     = this.GetComponent<Rigidbody2D>();
        this._animator = this.GetComponent<Animator>();
    }

    private void GoLeft(float horizontalInput)
    {
        this._body.velocity       = new Vector2(horizontalInput * this.horizontalSpeed, this._body.velocity.y);
        this.transform.localScale = new Vector2(-1, 1); // Flip to the left
        this._animator.SetBool(Walking, true);
    }

    private void GoRight(float horizontalInput)
    {
        this._body.velocity       = new Vector2(horizontalInput * this.horizontalSpeed, this._body.velocity.y);
        this.transform.localScale = Vector2.one; // Flip to the right
        this._animator.SetBool(Walking, true);
    }

    private void Jump()
    {
        if (!this._grounded)
        {
            return; // if player is already jumping, do not jump again
        }

        this._body.velocity = new Vector2(this._body.velocity.x, this.verticalSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this._grounded = true;
            this._animator.SetBool(Jumping, false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this._grounded = false;
            this._animator.SetBool(Jumping, true);
        }
    }

    private void StayThere()
    {
        this._body.velocity = new Vector2(0f, this._body.velocity.y);
        this._animator.SetBool(Walking, false);
    }
    
    private void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal"); // -1 (Left) ---- 0 ---- (Right) 1

        switch (horizontalInput)
        {
            case < 0f:
                this.GoLeft(horizontalInput);
                break;
            case > 0f:
                this.GoRight(horizontalInput);
                break;
            default:
                this.StayThere();
                break;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            this.Jump();
        }
    }
}
