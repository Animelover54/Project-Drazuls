using UnityEngine;

public class Decay : MonoBehaviour
{
    public GameObject thisObject;
    private Material currentMaterial;
    public Material materialStart;
    public Material materialEnd;
    public float decaySpeed;  // Total time for the material transition in seconds

    private float elapsedTime = 0f;  // To track the elapsed time

    // Start is called before the first frame update
    void Start()
    {
        // Get the current material of the object
        currentMaterial = thisObject.GetComponent<Renderer>().material;

        // Initialize the material with the starting material properties
        currentMaterial.CopyPropertiesFromMaterial(materialStart);
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the elapsed time
        elapsedTime += Time.deltaTime;

        // Calculate the progress based on decaySpeed
        float progress = Mathf.Clamp01(elapsedTime / decaySpeed);

        // Lerp the color of the material
        currentMaterial.color = Color.Lerp(materialStart.color, materialEnd.color, progress);

        // Lerp other properties, for example metallic and smoothness
        currentMaterial.SetFloat("_Metallic", Mathf.Lerp(materialStart.GetFloat("_Metallic"), materialEnd.GetFloat("_Metallic"), progress));
        currentMaterial.SetFloat("_Glossiness", Mathf.Lerp(materialStart.GetFloat("_Glossiness"), materialEnd.GetFloat("_Glossiness"), progress));

        // When fully transitioned, ensure all properties are from materialEnd
        if (progress >= 1f)
        {
            currentMaterial.CopyPropertiesFromMaterial(materialEnd);
        }
    }
}
