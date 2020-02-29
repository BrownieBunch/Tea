using UnityEngine;
using System.Collections;

public class KoiSwim : MonoBehaviour
{

		public float speed = 5;
		public float waitTime = .3f;
		public float turnSpeed = 90;

		public Transform pointHolder;
		public Transform[] randomPath;
		void Start()
		{
		//NOT FINISHED!!!
			Vector3[] waypoints = new Vector3[pointHolder.childCount];
			for (int i = 0; i < waypoints.Length; i++)
			{
				waypoints[i] = pointHolder.GetChild(i).position;
				waypoints[i] = new Vector3(waypoints[i].x, waypoints[i].y, waypoints[i].z);
			}

			StartCoroutine(FollowPath(waypoints));

		}

		IEnumerator FollowPath(Vector3[] waypoints)
		{
			transform.position = waypoints[0];

			int targetWaypointIndex = 1;
			Vector3 targetWaypoint = waypoints[targetWaypointIndex];
			transform.LookAt(targetWaypoint);

			while (true)
			{
				transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
				if (transform.position == targetWaypoint)
				{
				//serial
				//targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
					targetWaypointIndex = Random.Range(0, waypoints.Length - 1);
					targetWaypoint = waypoints[targetWaypointIndex];
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

			while (Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle) > 0.05f)
			{
				float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
				transform.eulerAngles = Vector3.up * angle;
				yield return null;
			}
		}

		void OnDrawGizmos()
		{
			Vector3 startPosition = pointHolder.GetChild(0).position;
			Vector3 previousPosition = startPosition;

			foreach (Transform waypoint in pointHolder)
			{
				Gizmos.DrawSphere(waypoint.position, .3f);
				Gizmos.DrawLine(previousPosition, waypoint.position);
				previousPosition = waypoint.position;
			}
			Gizmos.DrawLine(previousPosition, startPosition);
		}

	}
