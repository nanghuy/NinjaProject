using UnityEngine;
using System.Collections;

public class RunMushroom : MonoBehaviour {

    private bool facingRight;

    [SerializeField]
    private float speedMoveMush;

    private float rootPosition;
    // Use this for initialization
    void Start() {
        rootPosition = transform.position.x;
        facingRight = true;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(speedMoveMush * Time.deltaTime, 0, 0);
        if (transform.position.x < rootPosition - 3)
        {
            speedMoveMush = -speedMoveMush;
            Flip();
        }
        if (transform.position.x > rootPosition + 3)
        {
            speedMoveMush = -speedMoveMush;
            Flip();
        }
    }

    private void Flip() {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }
}
