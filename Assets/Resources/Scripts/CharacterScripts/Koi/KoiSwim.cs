using UnityEngine;
using System.Collections;

public class KoiSwim : MonoBehaviour
{

		public float speed = 5;
		public float waitTime = .3f;
		public float turnSpeed = 90;

		public Transform pointHolder;
		public Transform[] path;

	void Start()
	{
		path = new Transform[pointHolder.childCount];
		for (int i = 0; i < pointHolder.childCount; i++)
		{ 
			 path[i] = pointHolder.GetChild(Random.Range(0, pointHolder.childCount - 1));
		}

     	StartCoroutine(FollowPath(path));

		}

		IEnumerator FollowPath(Transform[] waypoints)
		{
			transform.position = waypoints[0].position;

			int targetWaypointIndex = 1;
			Vector3 targetWaypoint = waypoints[targetWaypointIndex].position;
			transform.LookAt(targetWaypoint);

			while (true)
			{
				transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
			if  (Mathf.Approximately(transform.position.x, targetWaypoint.x))
		{
				    Debug.Log(this.gameObject.name + "has arrived at node " + targetWaypointIndex + ".");
				    targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
					targetWaypoint = waypoints[targetWaypointIndex].position;
					yield return new WaitForSeconds(waitTime);
					yield return StartCoroutine(TurnToFace(targetWaypoint));
				}
				yield return null;
			}
		}

		IEnumerator TurnToFace(Vector3 lookTarget)
		{
			Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
			float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

			while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
			{
				float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
				transform.eulerAngles = Vector3.up * angle;
				yield return null;
			}
		}

		void OnDrawGizmos()
		{
		if (path.Length != 0)
		{ 
			Vector3 startPosition = path[0].position;
			Vector3 previousPosition = startPosition;

			foreach (Transform point in path)
			{
				Gizmos.DrawSphere(point.position, .3f);
				Gizmos.DrawLine(previousPosition, point.position);
				previousPosition = point.position;
			}
			Gizmos.DrawLine(previousPosition, startPosition);
		}
	}

}
