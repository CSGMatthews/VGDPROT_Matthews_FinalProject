using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject m_warpMate;
    private bool m_allowWarp = true;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision!");
        if (other.CompareTag("Player") && m_allowWarp)
        {
            Debug.Log("Warp!");
            m_warpMate.GetComponent<Portal>().AllowWarp(false);
            other.transform.position = m_warpMate.transform.position;
            Debug.Log(other.transform.position);
            Debug.Log(m_warpMate.transform.position);
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