using UnityEngine;

public class BlackHoleEffect : MonoBehaviour
{
    public Material m_Mat = null;
    [Range(0.01f, 0.2f)]
    public float m_DarkRange = 0.1f;
    [Range(-2.5f, -1f)]
    public float m_Distortion = -2f;
    [Range(0.05f, 0.3f)]
    public float m_Form = 0.2f;

    public Transform blackHole;

    private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
    {
        Vector2 screenCoordinates = Camera.main.WorldToViewportPoint(blackHole.position);
        print(screenCoordinates);
        m_Mat.SetVector("_Center", new Vector4(screenCoordinates.x, screenCoordinates.y, 0f, 0f));
        m_Mat.SetFloat("_DarkRange", m_DarkRange);
        m_Mat.SetFloat("_Distortion", m_Distortion);
        m_Mat.SetFloat("_Form", m_Form);
        Graphics.Blit(sourceTexture, destTexture, m_Mat);
    }
}
