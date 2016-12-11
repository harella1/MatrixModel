using System.Collections.Generic;

namespace DesignPatterns.Interpreter
{
    public class Context
    {
        private readonly Player m_Player;
        private readonly Stack<ContextState> m_States;

        public Context(Player player)
        {
            m_Player = player;
            m_States = new Stack<ContextState>();
            var state = new ContextState();
            m_States.Push(state);
        }

        public ContextState State
        {
            get
            {
                return m_States.Peek();
            }
        }

        public void Play()
        {
            m_Player.Play(State);
        }

        public void SaveState()
        {
            var state = State.Clone();
            m_States.Push(state);
        }

        public void RestoreState()
        {
            m_States.Pop();
        }
    }
}