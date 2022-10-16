using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] float upForce = 1f;
    [SerializeField] float sideForce = 1f;

    private void Start()
    {
        var xForce = Random.Range(-sideForce, sideForce);
        var yForce = Random.Range(upForce / 2f, upForce);
        var zForce = Random.Range(-sideForce, sideForce);
        
        var force = new Vector3(xForce, yForce, zForce);
        
        GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }
}
