using UnityEngine;

public class ThornShooter : MonoBehaviour
{
    public GameObject thornPrefab;

    private GameObject currThorn;
    private Vector3 thornTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currThorn != null && Vector3.Distance(thornTarget, currThorn.transform.position) > 0.5f)
        {
            currThorn.transform.position = Vector3.MoveTowards(currThorn.transform.position, thornTarget, 0.45f);
        } else
        {
            Destroy(currThorn);
            currThorn = null;
        }
    }

    public void ShootThorn(Vector3 target)
    {
        currThorn = Instantiate(thornPrefab, transform.position, thornPrefab.transform.rotation);
        thornTarget = target;

        // Calculate direction to the target
        Vector3 direction = (thornTarget - currThorn.transform.position).normalized;

        // Calculate rotation to look at the target
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        // Apply rotation to the thorn
        currThorn.transform.rotation = lookRotation;
    }
}
