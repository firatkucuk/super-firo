using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float       horizontalSpeed;
    [SerializeField] private float       verticalSpeed;
    private                  Rigidbody2D _body;
    private                  Animator    _animator;

    private void Awake()
    {
        this._body     = this.GetComponent<Rigidbody2D>();
        this._animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // -1 (Left) ---- 0 ---- (Right) 1
        this._body.velocity = new Vector2(horizontalInput * this.horizontalSpeed, this._body.velocity.y);

        this.transform.localScale = horizontalInput switch
        {
            < 0f => new Vector2(-1, 1),       // If pressed left flip the character
            > 0f => Vector2.one,              // If pressed right flip the character normal state
            _    => this.transform.localScale // If in idle mode keep the latest state
        };

        if (Input.GetKey(KeyCode.Space))
        {
            this._body.velocity = new Vector2(this._body.velocity.x, verticalSpeed);
        }
        
        this._animator.SetBool("walk", horizontalInput != 0f);
    }
}
