using UnityEngine;

public class DinoSpawnerScript : MonoBehaviour
{
    public GameObject dino;
    public TimerScript gameTime;
    public float spawnRate = 5;
    public float dinoTime;
    public float distanceOffset = 5;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameTime = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerScript>();
    }

    // Update is called once per frame
    void Update()
    {
       if (gameTime.isGameActive == true && gameTime.timeRemaining > 0 && gameTime.isPaused == false)
       {
        if (dinoTime < spawnRate)
        {
            dinoTime = dinoTime + Time.deltaTime;
        }
        else
        {
            spawnDino();
            dinoTime = 0;
        }
        }
    }

    void spawnDino()
    {
        float xPoint1 = transform.position.y - distanceOffset;
        float xPoint2 = transform.position.y + distanceOffset;
        Instantiate(dino, new Vector3(Random.Range(xPoint1,xPoint2), transform.position.y, transform.position.z), transform.rotation);
    }
}
