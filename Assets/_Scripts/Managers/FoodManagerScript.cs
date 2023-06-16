using System.Collections.Generic;
using UnityEngine;

public class FoodManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject fruit;
    private SnakeScript snake;
    private FruitScript currentFruit;

    private List<Vector2> snakeLocations = new List<Vector2>();

    private void Awake()
    {
        snake = GameObject.FindGameObjectWithTag("Head").GetComponent<SnakeScript>();    
    }

    void Start()
    {

    }

    void Update()
    {
        // Assigns a fruit to this manager, if a fruit cannot be found then it would spawn one 

        if (currentFruit == null )
        {
            try
            {
                currentFruit = GameObject.FindGameObjectWithTag("Food").GetComponent<FruitScript>();
            } catch (System.Exception)
            {
                _fruitSpawnLocationHandler();
                _spawnFruit();
            }
        } 
    }

    private void _spawnFruit ()
    {
        bool hasOverlapped = false;
        // bigger screen
        int randomX = Mathf.RoundToInt(Random.Range(-25, 25));
        int randomY = Mathf.RoundToInt(Random.Range(-13, 13));

        // smaller screen
        //int randomX = Mathf.RoundToInt(Random.Range(-8, 8));
        //int randomY = Mathf.RoundToInt(Random.Range(-4, 4));

        Vector2 randomPos = new Vector2(randomX, randomY);

        foreach (Vector2 positions in snakeLocations)
        {
            Debug.Log("Checking for overlaps");
            if (positions == randomPos)
            {
                Debug.Log("POSITION OVERLAPPED. WILL GET ANOTHER RANDOM POS.");
                hasOverlapped = true;
                break;
            }
        }

        if (randomPos == new Vector2(snake.transform.position.x, snake.transform.position.y))
        {
            hasOverlapped = true;
        }

        if(!hasOverlapped)
        {
            Instantiate(fruit, randomPos, Quaternion.identity);
        }

        snakeLocations.Clear();
    }

    private void _fruitSpawnLocationHandler()
    {
        if(snake.SnakeSegments.Count > 0)
        {
            foreach (GameObject segments in snake.SnakeSegments)
            {
                snakeLocations.Add(segments.transform.position);
            }
        }
    }

}
