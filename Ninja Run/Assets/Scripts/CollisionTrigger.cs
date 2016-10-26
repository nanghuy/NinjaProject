using UnityEngine;
using System.Collections;

public class CollisionTrigger : MonoBehaviour {

    private BoxCollider2D playerCollider;

    [SerializeField]
    private BoxCollider2D flatformCollider;

    [SerializeField]
    private BoxCollider2D flatformTriger;

	// Use this for initialization
	void Start () {
        playerCollider = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(flatformCollider, flatformTriger, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player")
        {
            print("Player");
            Physics2D.IgnoreCollision(flatformCollider, playerCollider, true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Player")
        {
            print("hello");
            Physics2D.IgnoreCollision(flatformCollider, playerCollider, false);
        }
    }

    }
