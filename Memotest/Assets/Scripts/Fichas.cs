using UnityEngine;

public class Fichas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Rotar");
        transform.Rotate(Vector3.right, 180);
    }
}
