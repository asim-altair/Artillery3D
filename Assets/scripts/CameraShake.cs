using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }
    public void ShakeTrigger(float shakeDurration, float shakeAmplitued)
    {
        StartCoroutine(Shake(shakeDurration, shakeAmplitued));
    }

    private IEnumerator Shake(float shakeDurration, float shakeAmplitued)
    {
        float elapsedTime = 0;

        while(elapsedTime < shakeDurration)
        {
            float shakeX = Random.Range(-1, 1) * shakeAmplitued;
            float shakeY = Random.Range(-1, 1) * shakeAmplitued;
            float shakeZ = Random.Range(-1, 1) * shakeAmplitued;

            transform.localPosition = new Vector3(originalPosition.x + shakeX, originalPosition.y + shakeY, originalPosition.z + shakeZ);

            elapsedTime += Time.deltaTime;
            yield return null;
        } 

        transform.localPosition = originalPosition;
    }
}
