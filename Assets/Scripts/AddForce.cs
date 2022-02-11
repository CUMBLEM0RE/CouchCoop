using UnityEngine;

public class AddForce : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 80000f;
    Vector3 originalPos;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        originalPos = gameObject.transform.position;

    }

    void Update()
    {
        if (Input.GetKey("f"))
        {
            m_Rigidbody.AddForce(transform.forward * m_Thrust);
            Invoke("ResetCooldown", 1.0f);
        }
    }

    void ResetCooldown()
    {
        gameObject.transform.position = originalPos;
    }
}
