using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    public GameObject m_warpMate;
    private bool m_allowWarp = true;
    private Text m_winLabel;

    private void Start()
    {
        m_winLabel = FindObjectOfType<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision!");
        if (other.CompareTag("Player") && m_allowWarp)
        {
            m_winLabel.enabled = true;
            m_warpMate.GetComponent<Portal>().AllowWarp(false);
            other.GetComponentInParent<CharacterController>().enabled = false;
            other.transform.position = m_warpMate.transform.position;
            other.GetComponentInParent<CharacterController>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_allowWarp = true;
    }

    public void AllowWarp(bool allowed)
    {
        m_allowWarp = allowed;
    }
}