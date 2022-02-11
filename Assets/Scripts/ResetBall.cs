using UnityEngine;

public class ResetBall : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 0f;
    public Vector3 originalPos;

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
        }
        if (Input.GetKeyUp("f"))
        {
            Invoke("ResetCooldown", 1.0f);
        }
    }

    void ResetCooldown()
    {
        gameObject.transform.position = originalPos;
    }
}
