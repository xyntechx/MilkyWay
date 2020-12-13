using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CharacterController2D : MonoBehaviour
{
	private Rigidbody2D m_Rigidbody2D;
	private Vector3 m_Velocity = Vector3.zero;
	private float degrees = -90f;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

	public void Move(float horizontalMove, float verticalMove, float moveSpeed)
	{
		Vector3 oldPos = this.transform.position;
     	float newX = horizontalMove * moveSpeed * Time.deltaTime;
     	float newY = verticalMove * moveSpeed * Time.deltaTime;
		m_Rigidbody2D.MovePosition(new Vector3(oldPos.x + newX, oldPos.y + newY, oldPos.z));
	}

	public void Rotate(float horizontalMove, float verticalMove)
	{
		if (horizontalMove == -1)
		{
			degrees = 90f;
		}
		else if (horizontalMove == 1)
		{
			degrees = -90f;
		}
		else if (verticalMove == -1)
		{
			degrees = -180f;
		}
		else if (verticalMove == 1)
		{
			degrees = 0f;
		}
		transform.eulerAngles = Vector3.forward * degrees;
	}
}