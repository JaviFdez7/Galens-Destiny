using UnityEngine;
using UnityEngine.Rendering.Universal; // Asegúrate de tener esta línea

public class LightAnimation : MonoBehaviour
{
    public Light2D targetLight;

    public float sweepSpeed = 30.0f; // Velocidad del barrido en grados por segundo

    private float currentAngle = 0.0f;
    private int angleDirection = 1;

    private void Update()
    {


        // Barrido de ángulo z
        currentAngle += sweepSpeed * angleDirection * Time.deltaTime;
        currentAngle = Mathf.Clamp(currentAngle, 0.0f, 45.0f); // Limitar a 45 grados

        if (currentAngle >= 45.0f || currentAngle <= 0.0f)
        {
            angleDirection *= -1; // Cambiar dirección al llegar a los límites
        }

        // Aplicar rotación en ángulo z
        Quaternion rotation = Quaternion.Euler(0f, 0f, currentAngle);
        targetLight.transform.localRotation = rotation;
    }
}