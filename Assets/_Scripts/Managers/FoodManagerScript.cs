using UnityEngine;

public class FoodManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject fruit;
    private FruitScript currentFruit;

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
                _spawnFruit();
            }
        } 
    }

    private void _spawnFruit ()
    {
        int randomX = Mathf.RoundToInt(Random.Range(-25, 25));
        int randomY = Mathf.RoundToInt(Random.Range(-13, 13));

        Vector2 randomPos = new Vector2(randomX, randomY);
        Instantiate(fruit, randomPos, Quaternion.identity);
    }
}
