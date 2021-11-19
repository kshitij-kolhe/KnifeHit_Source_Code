using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    [SerializeField]
    private float knifeSpeed = 0;

    private bool isActive = true;

    private Rigidbody2D rigidbody;

    [SerializeField]
    private Collider2D collider = null;
    [SerializeField]
    private BoxCollider2D boxCollider_2 = null;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider_2.enabled = false;
    }

    private void Update()
    {
        if(isActive && Input.GetMouseButtonDown(0))
        {
            rigidbody.AddForce(new Vector2(0, knifeSpeed), ForceMode2D.Impulse);
            rigidbody.gravityScale = 1;

            GameManager.Instance.gameUi.DecrementKnifeIcon();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActive)
            return;

        isActive = false;

        if (collision.gameObject.tag == "Log")
        {
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.transform);

            collider.enabled = false;
            boxCollider_2.enabled = true;


            GameManager.Instance.OnSuccessfullKnifeHit();
        }
        else if(collision.gameObject.tag == "Knife")
        {
            rigidbody.velocity = new Vector2(Random.Range(-10, 10), -5);
            rigidbody.AddTorque(2, ForceMode2D.Impulse);

            GameManager.Instance.GetLogMotor().StopAllCoroutines();
            GameManager.Instance.StartGameOverSequence(false);
        }
    }

}
