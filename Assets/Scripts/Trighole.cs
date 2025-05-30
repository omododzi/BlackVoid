using UnityEngine;
using System.Collections;

public class Trighole : MonoBehaviour
{
    [Header("Настройки")]
    public float minObjsize = 1f;
    public float destroyDelay = 5f;
    public float scaleIncreaseFactor = 0.1f;
    public float scaleAnimDuration = 0.5f;

    private SphereCollider holeCollider;
    private Transform platformTransform;
    private bool isScaling = false;

    void Start()
    {
        holeCollider = GetComponent<SphereCollider>();
        platformTransform = transform.parent;
    }

    void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Fallable")) return;

        float objSize = Mathf.Max(other.bounds.size.x, other.bounds.size.z);
        float holeSize = holeCollider.radius * 2f * transform.lossyScale.x;

        Rigidbody rb = other.GetComponent<Rigidbody>();
        if(rb == null) return;

        if(objSize > holeSize * minObjsize)
        {
            rb.isKinematic = true;
           
        }
        else
        { 
            //StartCoroutine(ProcessBigObject(other.transform, rb));
            ProcessSmallObject(other.gameObject, objSize, rb);
        }
    }

    IEnumerator ProcessBigObject(Transform obj, Rigidbody rb)
    {
        float duration = 2f;
        float elapsed = 0f;
        Vector3 startPos = obj.position;
        Vector3 endPos = transform.position;

        while(elapsed < duration)
        {
            obj.position = Vector3.Lerp(startPos, endPos, elapsed/duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        rb.isKinematic = false;
        Destroy(obj.gameObject, destroyDelay);
    }

    void ProcessSmallObject(GameObject obj, float objSize, Rigidbody rb)
    {
        rb.isKinematic = false;
        Destroy(obj, destroyDelay);

        if(!isScaling)
        {
            StartCoroutine(ScalePlatform(objSize));
        }
    }

    IEnumerator ScalePlatform(float objSize)
    {
        isScaling = true;
        Vector3 startScale = platformTransform.localScale;
        Vector3 targetScale = startScale + (Vector3.one * objSize * scaleIncreaseFactor);
        float elapsed = 0f;

        while(elapsed < scaleAnimDuration)
        {
            platformTransform.localScale = Vector3.Lerp(
                startScale, 
                targetScale, 
                elapsed/scaleAnimDuration
            );
            elapsed += Time.deltaTime;
            yield return null;
        }

        isScaling = false;
    }
}