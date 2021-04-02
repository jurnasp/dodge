using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountScore : MonoBehaviour
{
    private Stack<int> _bufferStack;
    private const int BufferSize = 20;
    private int _score;
    public Text highScoreText;
    private int _timeSinceLastPush;
    public int bufferLeeway = 50;

    private void Start()
    {
        _bufferStack = new Stack<int>(BufferSize);
        _timeSinceLastPush = DateTime.Now.Millisecond;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.transform.position.z < transform.position.z
            && !_bufferStack.Contains(other.GetInstanceID()))
        {
            // @Todo Test if check is right 
            if (_bufferStack.Count > BufferSize)
                _bufferStack.Pop();
            _bufferStack.Push(other.GetInstanceID());

            // @Todo Implement better way of detecting grouped Obstacle GameObjects
            if(_timeSinceLastPush > DateTime.Now.Millisecond - bufferLeeway)
            {
                _score++;
                highScoreText.text = _score.ToString();
            }
            _timeSinceLastPush = DateTime.Now.Millisecond;
        }
    }
}
