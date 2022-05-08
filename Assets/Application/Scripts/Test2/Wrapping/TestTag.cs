using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using until.system;


namespace until.test2
{
    public enum Tag
    {
        None,
        Visible,
    }

    public class TestTag : Taggable<TestTag>
    {
        public Tag[] ObjectTags => _ObjectTags;
        [SerializeField]
        private Tag[] _ObjectTags = null;
    }
}
