using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

	// どのボールを吸い寄せるかタグで指定
	public string activeTag;


	void OnTriggerStay (Collider other)
	{
		// コライダーに触れているオブジェクトのRigidbodyコンポーネントを取得
		Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

		//ボールがどの方向にあるかを計算
		Vector3 direction = transform.position - other.gameObject.transform.position;
		direction.Normalize();

		//タグに応じてポールに力を加える
		if (other.gameObject.tag == activeTag)
		{
			// 中心地点でボールを止めるため速度を減速させる
			r.velocity *= 0.9f;

			r.AddForce(direction * r.mass * 20.0f);
		}
		else
		{
			r.AddForce(-direction * r.mass * 80.0f);
		}
	}

}
