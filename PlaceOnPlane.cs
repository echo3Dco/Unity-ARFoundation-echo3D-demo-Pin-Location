using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

/// <summary>
/// Listens for touch events and performs an AR raycast from the screen touch point.
/// AR raycasts will only hit detected trackables like feature points and planes.
///
/// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
/// and moved to the hit position.
/// </summary>
[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnPlane : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Instantiates this prefab on a plane at the touch location.")]
    GameObject m_PlacedPrefab;

    /// <summary>
    /// The prefab to instantiate on touch.
    /// </summary>
    public GameObject placedPrefab
    {
        get { return m_PlacedPrefab; }
        set { m_PlacedPrefab = value; }
    }

    /// <summary>
    /// The object instantiated as a result of a successful raycast intersection with a plane.
    /// </summary>
    public GameObject spawnedObject { get; private set; }

    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount <= 0)
            return;

        else if (Input.touchCount > 1) {
              if (!IsPointOverUIObject(Input.GetTouch(0).position) && spawnedObject != null) {
                  // Store both touches.
                  Touch touchZero = Input.GetTouch(0);
                  Touch touchOne = Input.GetTouch(1);
                  // Calculate previous position
                  Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                  Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
                  // Find the magnitude of the vector (the distance) between the touches in each frame.
                  float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                  float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
                  // Find the difference in the distances between each frame.
                  float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
                  float pinchAmount = deltaMagnitudeDiff * 0.02f * Time.deltaTime;
                  spawnedObject.transform.localScale -= new Vector3(pinchAmount, pinchAmount, pinchAmount);
                  // Clamp scale
                  float Min = 0.005f;
                  float Max = 3f;
                  spawnedObject.transform.localScale = new Vector3(
                      Mathf.Clamp(spawnedObject.transform.localScale.x, Min, Max),
                      Mathf.Clamp(spawnedObject.transform.localScale.y, Min, Max),
                      Mathf.Clamp(spawnedObject.transform.localScale.z, Min, Max)
                  );
              }
        }
        else if (Input.touchCount == 1) {
            if (!IsPointOverUIObject(Input.GetTouch(0).position) && m_RaycastManager.Raycast(Input.GetTouch(0).position, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                // Raycast hits are sorted by distance, so the first one
                // will be the closest hit.
                var hitPose = s_Hits[0].pose;

                if (spawnedObject == null)
                {
                    spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    spawnedObject.transform.position = hitPose.position;
                }
            }
        }
    }

    private bool IsPointOverUIObject(Vector2 pos)
    {
      if (EventSystem.current.IsPointerOverGameObject())
          return false;

      PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
      eventDataCurrentPosition.position = new Vector2(pos.x, pos.y);
      List<RaycastResult> results = new List<RaycastResult>();
      EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
      return results.Count > 0;
    }

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    ARRaycastManager m_RaycastManager;
}
