using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public interface IQuest : IDisposable
    {
        event EventHandler<IQuest> QuestCompleted;

        bool IsCompleted { get; }

        void Reset();
    }
}