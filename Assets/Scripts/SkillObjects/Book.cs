using UnityEngine;
using System.Collections;

public class Book : MonoBehaviour 
{
    public float speed;
    private float angularSpeed = 360;

    public void Initialize(float direction)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction * speed, 0);
        GetComponent<Rigidbody2D>().angularVelocity = angularSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
			Destroy(gameObject);
        }
        else if (collision.gameObject.name == "Student")
        {
			Destroy(gameObject); 
			GameObject stan = Instantiate(Resources.Load("SkillObjects/HeroStan", typeof(GameObject)), collision.transform.position, Quaternion.identity) as GameObject;
			stan.gameObject.transform.SetParent(collision.transform);
        }
    }
}
