using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class Outline : MonoBehaviour
{
	[Header("Normal Expansion Parameters")]
	public Color m_OutlineColor = Color.green;
	[Range(0.01f, 0.02f)] public float m_OutlineWidth = 0.02f;
	[Range(0f, 1f)] public float m_OutlineFactor = 1f;
	public bool m_WriteZ = false;
	public bool m_BasedOnVertexColorR = false;
	public bool m_OutlineOnly = false;
	[Header("Normal Expansion Flash")]
	public Color m_OverlayColor = Color.red;
	[Range(0f, 0.6f)] public float m_Overlay = 0f;
	public bool m_OverlayFlash = false;
	[Range(1f, 6f)] public float m_OverlayFlashSpeed = 3f;
	[Header("Internal")]
	public Material[] m_BackupMats;
	public Renderer m_Rd;
	public Shader m_SdrOutlineOnly, m_SdrOutlineDiffuse, m_SdrOriginal;

    private void Start()
    {
        //StartCoroutine("Initialize");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine("Initialize");
            Debug.Log("started this thing");
        }
        
    }

    IEnumerator Initialize ()
    {
        yield return new WaitForSeconds(Random.Range(0, .05f));
        m_Rd = GetComponent<Renderer> ();
        yield return null;
		m_BackupMats = m_Rd.materials;
        yield return null;
        m_SdrOriginal = Shader.Find ("Legacy Shaders/Diffuse");
        yield return null;
        m_SdrOutlineOnly = Shader.Find ("Selected Effect --- Outline/Normal Expansion/Outline Only");
        yield return null;
        m_SdrOutlineDiffuse = Shader.Find ("Selected Effect --- Outline/Normal Expansion/Diffuse");
	}
	public void SetMaterialsFloat (string name, float f)
	{
		Material[] mats = m_Rd.materials;
		for (int i = 0; i < mats.Length; i++)
		{
			mats[i].SetFloat (name, f);
		}
	}
	public void UpdateSelfParameters ()
	{
		if (m_OverlayFlash)
		{
			float curve = Mathf.Sin (Time.time * m_OverlayFlashSpeed) * 0.5f + 0.5f;
			m_Overlay = curve * 0.6f;
		}
		
		Material[] mats = m_Rd.materials;
		for (int i = 0; i < mats.Length; i++)
		{
			mats[i].SetFloat ("_OutlineWidth", m_OutlineWidth);
			mats[i].SetColor ("_OutlineColor", m_OutlineColor);
			mats[i].SetFloat ("_OutlineFactor", m_OutlineFactor);
			mats[i].SetColor ("_OverlayColor", m_OverlayColor);
			mats[i].SetTexture ("_MainTex", m_BackupMats[i].GetTexture ("_MainTex"));
			mats[i].SetTextureOffset ("_MainTex", m_BackupMats[i].GetTextureOffset ("_MainTex"));
			mats[i].SetTextureScale ("_MainTex", m_BackupMats[i].GetTextureScale ("_MainTex"));
			mats[i].SetFloat ("_OutlineWriteZ", m_WriteZ ? 1f : 0f);
			mats[i].SetFloat ("_OutlineBasedVertexColorR", m_BasedOnVertexColorR ? 0f : 1f);
			mats[i].SetFloat ("_Overlay", m_Overlay);
		}
	}
	public void OutlineEnable ()
	{
		Material[] mats = m_Rd.materials;
		for (int i = 0; i < mats.Length; i++)
		{
			if (m_OutlineOnly)
				mats[i].shader = m_SdrOutlineOnly;
			else
				mats[i].shader = m_SdrOutlineDiffuse;
		}	
	}
	public void OutlineDisable ()
	{
		Material[] mats = m_Rd.materials;
		for (int i = 0; i < mats.Length; i++)
		{
			mats[i].shader = m_SdrOriginal;
		}
	}
}
