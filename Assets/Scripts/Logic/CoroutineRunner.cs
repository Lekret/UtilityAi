using System.Collections;
using UnityEngine;

namespace Logic
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}