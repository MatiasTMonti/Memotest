using UnityEngine;

public class GenerateCards : MonoBehaviour
{
    [SerializeField] private Transform fichas;
    [SerializeField] private GameObject cards;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject button = Instantiate(cards, new Vector3(2 * i, 0, 0), Quaternion.identity);
            button.name = "" + i;
            button.transform.SetParent(fichas, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
