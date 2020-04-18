using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest2
{
    public class LevelStatus
    {
        public event EventHandler FinishGameEvent;
        public event EventHandler GoToNextLevelEvent;
        public void SendFinishEvent()
        {
            FinishGameEvent(this, EventArgs.Empty);
        }
        public void SendNextLevelEvent()
        {
            GoToNextLevelEvent(this, EventArgs.Empty);
        }
    }
}
