﻿using UnityEngine;
using System.Collections;

public class basicAI : MonoBehaviour {

		public Transform target;
		public int moveSpeed;
		public float minDistance = 0.5f;
		public float maxDistance = 10f;
		public int health = 15;
        public bool isRight = true;

        private bool facingRight = true;
		
		private Transform myTransform;
		
		void Awake() {
			myTransform = transform;
            facingRight = isRight;
		}    
	
		void Start () {
			GameObject go = GameObject.FindGameObjectWithTag("Player");
			target = go.transform;
		}        
	
		public void takeDamage(int dmg)
			{
			Debug.Log("taking " + dmg);
			health -= dmg;
			}
		
		void FixedUpdate () {
            float distance = Mathf.Abs(target.position.x - myTransform.position.x);
            if (distance < maxDistance && distance > minDistance) {
                if (target.position.x < myTransform.position.x) { 
                    //myTransform.position -= myTransform.right * moveSpeed * Time.deltaTime;
                    if (facingRight) {
                        Flip();
                    }
                } else if (target.position.x > myTransform.position.x) {
                    //myTransform.position += myTransform.right * moveSpeed * Time.deltaTime;
                    if (!facingRight) {
                        Flip();
                    }
            
                
                } 
                rigidbody2D.velocity = new Vector2(moveSpeed * (facingRight ? 1 : -1), rigidbody2D.velocity.y);
            } else {
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            }
				if (health <=  0)
					{
					Destroy(gameObject);
					}
		}

        private void Flip() {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
}