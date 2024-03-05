using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }
    public float shakeDuration = 0.5f;
    public float shakeAmount = 0.1f;
    private Vector3 originalPosition;

    private void Awake()
    {
        Instance = this; 
    }
    private void Start()
    {
        originalPosition = transform.position;
    }

    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * shakeAmount;
            transform.position = originalPosition + randomOffset;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
    }
}