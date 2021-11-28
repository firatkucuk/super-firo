using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float       speed;
    private Rigidbody2D _body;

    private void Awake()
    {
        this._body = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        this._body.velocity = new Vector2(Input.GetAxis("Horizontal") * this.speed, this._body.velocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            this._body.velocity = new Vector2(this._body.velocity.x, speed);
        }
    }
}