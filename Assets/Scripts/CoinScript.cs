using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float rotateSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateSpeed,0,0);
    }
}
