using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using DesignPatterns.Interpreter;

namespace DesignPatterns.Interpreter
{
    public class MidiPlayer : Player
    {
        private int m_Handle = 0;

        public override void Init()
        {
            int result = midiOutOpen(ref m_Handle, 0, null, 0, 0);
            if (result!=0) throw new InvalidOperationException("Unable to initialize MIDI.");
        }

        private delegate void MidiCallback(int handle, int msg, int instance, int param1, int param2);

        [DllImport("winmm.dll")]
        private static extern int midiOutOpen(ref int handle, int deviceId, MidiCallback proc, int instance, int flags);

        [DllImport("winmm.dll")]
        private static extern int midiOutClose(ref int handle);

        [DllImport("winmm.dll")]
        private static extern int midiOutShortMsg(int handle, int message);
              
        protected override void PlayPause(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        protected override void PlaySound(int milliseconds, int stepsToA4)
        {
            const int onMessage = 0x00400090;
            const int offMessage = 0x00000090;

            int noteMessage = (stepsToA4 + 65) << 8;
            midiOutShortMsg(m_Handle, onMessage + noteMessage);
            Thread.Sleep(milliseconds);
            midiOutShortMsg(m_Handle, offMessage + noteMessage);
        }

        public override void Dispose()
        {
            if (m_Handle != 0)
            {
                midiOutClose(ref m_Handle);
                m_Handle=0;
            }
        }
    }
}