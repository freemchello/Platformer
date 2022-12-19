using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class ScrollBackgroundTest : MonoBehaviour
    {
        private Transform cameraTransform;
        private Transform[] layers;
        private float viewZone = 1;
        private int leftIndex;
        private int rightIndex;
        public float backgroundSize;

        void Start()
        {
            cameraTransform = Camera.main.transform;
            layers = new Transform[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                layers[i] = transform.GetChild(i);

            }

            leftIndex = 0;
            rightIndex = layers.Length - 1;
        }
        void Update()
        {
           if(cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
            {
                ScrollLeft();
            }
            if (cameraTransform.position.x > (layers[rightIndex].transform.position.x + viewZone))
            {
                ScrollRight();
            }
        }

        private void ScrollLeft()
        {
            int lastRight = rightIndex;
            layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
            leftIndex = rightIndex;
            rightIndex--;

            if(rightIndex < 0)
            {
                rightIndex = layers.Length - 1;
            }
        }

        private void ScrollRight()
        {
            int lastRight = leftIndex;
            layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
            rightIndex = leftIndex;
            leftIndex++;

            if (leftIndex == layers.Length)
            {
                leftIndex = 0;
            }
        }
    }
}