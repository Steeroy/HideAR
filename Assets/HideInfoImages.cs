using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class HideInfoImages : MonoBehaviour
{
    // This is a reference to the AR tracked image manager component
    private ARTrackedImageManager _aRTracked;

    // This is a list of prefabs to instantiate
    public GameObject[] ARPrefabsArray;

    // This will keep a dictionary of created prefabs
    private readonly Dictionary<string, GameObject> _createdPrefabs = new Dictionary<string, GameObject>();

    void Awake()
    {
        // This will cache a reference to the tracked image manager component
        _aRTracked = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        // This will attach an event handler when tracked images change 
        _aRTracked.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        // This will remove an event handler
        _aRTracked.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    // This is the event handler
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        // This will loop through all new tracked images that have been detected
        foreach (var item in args.added)
        {

            // This gets the name of the reference image
            var imageName = item.referenceImage.name;

            // This loops over the array prefabs
            foreach (var itemPrefab in ARPrefabsArray)
            {
                // This checks whether this prefab matches the tracked image name
                // This also checks if the current prefab hasn't already been created
                if(string.Compare(itemPrefab.name, imageName, StringComparison.OrdinalIgnoreCase) == 0 && !_createdPrefabs.ContainsKey(imageName))
                {
                    // Instantiate the prefab, parenting it to the ARTrackedImage
                    var newPrefabInstance = Instantiate(itemPrefab, item.transform);

                    // Add the created prefab to our array
                    _createdPrefabs[imageName] = newPrefabInstance;
                }
            }
        }

        // For all prefabs that have been created so far, this will set them active or not depending on whether their corresponding image is currently being tracked
        foreach (var trackedImage in args.updated)
        {
            _createdPrefabs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
        }

        // If the AR subsystem has given up looking for the tracked image
        foreach ( var trackedImage in args.removed)
        {
            // Destroy its prefab
            Destroy(_createdPrefabs[trackedImage.referenceImage.name]);

            // Also remove the instance from our array
            _createdPrefabs.Remove(trackedImage.referenceImage.name);
        }
    }
}
