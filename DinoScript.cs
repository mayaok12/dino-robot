using Unity.VisualScripting;
using UnityEngine;

public class DinoScript : MonoBehaviour
{
    public TimerScript gameTime;
    public bool isCaught = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameTime = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCaught == false)
        {
            float waitDinos = 0;
            if (waitDinos < 3)
            {
                waitDinos += Time.deltaTime;
            }
            transform.position = transform.position + (Vector3.up * 20 * Time.deltaTime);
            waitDinos = 0;
            if (waitDinos < 3)
            {
                waitDinos += Time.deltaTime;
            }
            transform.position = transform.position + (Vector3.down * 20 * Time.deltaTime);
        } 
        if (gameTime.timeRemaining <= 0)
        {
            Debug.Log("Dino Deleted");
            Destroy(gameObject);
        }
    }

    void Caught()
    {
        Debug.Log("Dino Deleted");
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider collider)
    {
        Caught();
    }
}
