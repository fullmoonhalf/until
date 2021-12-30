using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace until.modules.bullet
{
    public interface BulletEmitContext
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public int ProgramCount { get; set; }
        public int RepeatCount { get; set; }
        public BulletParameter Parameter { get; set; }
    }
}
