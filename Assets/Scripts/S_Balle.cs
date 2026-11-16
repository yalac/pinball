using UnityEngine;

public class S_Balle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void SetForce()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForceY(Random.Range(475, 675));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UnPoint")
        {
            Debug.Log("1 point");
        }
        if (collision.gameObject.tag == "DeuxPoint")
        {
            Debug.Log("2 point");
        }
        if (collision.gameObject.tag == "TroisPoint")
        {
            Debug.Log("3 point");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
