using System.Collections;
using UnityEngine;

public class BlackHoleTrap : MonoBehaviour
{
    /*
    [Header("Настройки")]
    [SerializeField] private float fallSpeed = 5f;
    [SerializeField] private float attractionRadius = 1f;
    [SerializeField] private float destroyDelay = 0.5f;
    [SerializeField] private float UpPower = 0.2f;
    [SerializeField] private float minObjectSize = 0.5f; // Минимальный размер объекта для поглощения
    [SerializeField] private LayerMask affectedLayers; // Какие слои могут поглощаться

    private void OnTriggerStay(Collider other)
    {
        // Проверяем условия
        if (other.isTrigger || 
            other.gameObject == gameObject || 
            !IsInAttractionZone(other.transform) ||
            !ShouldAffectObject(other))
            return;

        StartCoroutine(FallIntoHole(other));
    }

    private bool ShouldAffectObject(Collider other)
    {
        // 1. Проверяем, что объект на нужном слое
        if (((1 << other.gameObject.layer) & affectedLayers.value) == 0)
            return false;
            
        // 2. Проверяем размер объекта
        float objectSize = GetObjectSize(other);
        if (objectSize > attractionRadius * 3f) // Если объект слишком большой
            return false;
            
        // 3. Проверяем, что объект имеет Rigidbody
        if (other.GetComponent<Rigidbody>() == null)
            return false;
            
        return true;
    }

    private float GetObjectSize(Collider collider)
    {
        // Для простых коллайдеров
        if (collider is BoxCollider)
            return ((BoxCollider)collider).size.magnitude;
        if (collider is SphereCollider)
            return ((SphereCollider)collider).radius * 2;
        if (collider is CapsuleCollider)
            return ((CapsuleCollider)collider).height;
            
        // Для меш-коллайдеров
        return collider.bounds.size.magnitude;
    }

    private bool IsInAttractionZone(Transform obj)
    {
        Vector2 holePos = new Vector2(transform.position.x, transform.position.z);
        Vector2 objPos = new Vector2(obj.position.x, obj.position.z);
        float horizontalDistance = Vector2.Distance(holePos, objPos);

        return horizontalDistance < attractionRadius &&
               obj.position.y > transform.position.y;
    }

    private IEnumerator FallIntoHole(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        Vector3 startScale = other.transform.localScale;
        Vector3 startPosition = other.transform.position;
        float fallTime = 0f;

        // Отключаем физику для плавного движения
        rb.isKinematic = true;

        while (other != null && fallTime < destroyDelay)
        {
            if (other == null) yield break;
            
            // Плавное движение вниз с ускорением
            float progress = fallTime / destroyDelay;
            other.transform.position = Vector3.Lerp(
                startPosition, 
                transform.position, 
                progress * progress); // Квадратичная интерполяция для эффекта ускорения

            // Эффект уменьшения
            other.transform.localScale = Vector3.Lerp(
                startScale, 
                Vector3.zero, 
                progress);

            fallTime += Time.deltaTime;
            yield return null;
        }

        if (other != null)
        {
            // Увеличиваем черную дыру
            IncreaseBlackHoleSize();
            Destroy(other.gameObject);
        }
    }

    private void IncreaseBlackHoleSize()
    {
        Vector3 newScale = transform.localScale + (Vector3.one * UpPower);
        
        // Увеличиваем коллайдер пропорционально
        if (TryGetComponent<SphereCollider>(out var sphereCollider))
        {
            sphereCollider.radius *= 1f + (UpPower / transform.localScale.x);
        }
        
        transform.localScale = newScale;
        
        // Увеличиваем радиус притяжения
        attractionRadius *= 1f + (UpPower / transform.localScale.x);
        
        CameraFollow FC = Camera.main.GetComponent<CameraFollow>();
        FC.MakeMoreFar();
    }
    */
}