using UnityEngine;

public class WindowComponent : MonoBehaviour
{
    [SerializeField]
    ReflectionProbe reflectionProbeToCopy;

    ReflectionProbe reflectionProbe;
    MeshRenderer meshRenderer;

    void Awake()
    {
        if (reflectionProbeToCopy == null)
        {
            Debug.LogWarning("ReflectionProbeToCopy is empty");
            return;
        }

        if (reflectionProbe != null)
            Destroy(reflectionProbe.gameObject);

        CloneReflectionProbe();

        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.probeAnchor = reflectionProbe.transform;
    }

    void CloneReflectionProbe()
    {
        reflectionProbe = Instantiate(reflectionProbeToCopy, transform.position, transform.rotation, transform);
        reflectionProbe.bakedTexture = reflectionProbeToCopy.bakedTexture;
    }
}
