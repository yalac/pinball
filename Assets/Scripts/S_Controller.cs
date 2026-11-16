using UnityEngine;

public class S_Controller : MonoBehaviour
{
    public GameObject prefabBalle;

    [SerializeField]
    Transform SpawnPoint;

    bool apparition = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        apparition = true;
    }

    public void OnJump()
    {
        if (apparition)
        {
            GameObject balle = Instantiate(prefabBalle);
            balle.transform.position = SpawnPoint.position;
            balle.GetComponent<S_Balle>().SetForce();
            apparition = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}
