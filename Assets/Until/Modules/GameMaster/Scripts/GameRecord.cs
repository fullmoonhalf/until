using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace until.modules.gamemaster
{
    public class GameRecord
    {
        public string DisplayText => $"value={Value} count={Count} total={Total} Min={Min} Max={Max}";
        public int Value { get; private set; } = 0;
        public int Count { get; private set; } = 0;
        public int Total { get; private set; } = 0;
        public int Max { get; private set; } = 0;
        public int Min { get; private set; } = 0;

        public GameRecord()
        {
        }

        public void set(int value)
        {
            Value = value;
            ++Count;
            Total += value;
            Max = Math.Max(Max, value);
            Min = Math.Min(Min, value);
        }
    }
}
