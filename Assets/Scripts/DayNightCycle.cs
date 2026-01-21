using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light mainLight;
    public float rotationSpeed;

    void Update()
    {
        mainLight.transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
