using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    [SerializeField]
    GameObject hand;
    [SerializeField]
    GameObject _Laser;

    int SpawnCount;

    LineRenderer lineRenderer;
    Vector3 hitPos;
    Vector3 tmpPos;

    float lazerDistance = 10f;
    float lazerStartPointDistance = 0.15f;
    float lineWidth = 0.01f;

    void Reset()
    {
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
    }

    void Start()
    {
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
    }


    void Update()
    {
        OnRay();
    }

    void OnRay()
    {
        Vector2 direction = hand.transform.forward * lazerDistance;
        Vector2 rayStartPosition = hand.transform.forward * lazerStartPointDistance;
        Vector2 pos = hand.transform.position;
        Ray2D ray = new Ray2D(pos + rayStartPosition, hand.transform.forward);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100f);
        
        lineRenderer.SetPosition(0, pos + rayStartPosition);

        if (hit.collider.CompareTag("MiraUe"))
        {
            hitPos = hit.point;
            lineRenderer.SetPosition(1, hitPos);
            if (SpawnCount == 0)
            {
                Instantiate(_Laser, this.transform.position / 2, Quaternion.identity);
                SpawnCount++;
            }
            if (SpawnCount == 1)
            {
                this.transform.position = hitPos;
            }
        }
        else if (hit.collider.CompareTag("MiraSita"))
        {
            hitPos = hit.point;
            lineRenderer.SetPosition(1, hitPos);
            if (SpawnCount == 0)
            {
                Instantiate(_Laser, this.transform.position / 2, Quaternion.identity);
                SpawnCount++;
            }
            if (SpawnCount == 1)
            {
                this.transform.position = hitPos;
                SpawnCount = 0;
            }
        }
        else
        {
            lineRenderer.SetPosition(1, pos + direction);
        }

        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 0.1f);

    }
}
/*
 *      if (hit.collider.CompareTag("MiraUe"))
        {
            hitPos = hit.point;
            lineRenderer.SetPosition(1, hitPos);
            if (SpawnCount == 0)
            {
                Instantiate(_Laser, this.transform.position / 2, Quaternion.identity);
                SpawnCount++;
            }
            if(SpawnCount == 1)
            {
                this.transform.position = hitPos;
            }
        }
        else if (hit.collider.CompareTag("MiraSita"))
        {
            hitPos = hit.point;
            lineRenderer.SetPosition(1, hitPos);
            if (SpawnCount == 0)
            {
                Instantiate(_Laser, this.transform.position / 2, Quaternion.identity);
                SpawnCount++;
            }
            if (SpawnCount == 1)
            {
                this.transform.position = hitPos;
                SpawnCount = 0;
            }
        }

------------------------------------------------------------------------------------------

if (hit.collider.CompareTag("MiraUe"))
        {
            hitPos = hit.point;
            lineRenderer.SetPosition(1, hitPos);
            if (SpawnCount == 0)
            {
                Instantiate(_Laser, hitPos, hit.transform.rotation);
                SpawnCount++;
            }
        }
        else if (hit.collider.CompareTag("MiraSita"))
        {
            hitPos = hit.point;
            lineRenderer.SetPosition(1, hitPos);
            if(SpawnCount == 0)
            {
                Instantiate(_Laser, hitPos, hit.transform.rotation);
                SpawnCount++;
            }
        }
 */