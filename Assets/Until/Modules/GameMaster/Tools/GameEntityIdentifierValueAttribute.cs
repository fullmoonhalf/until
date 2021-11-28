using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



namespace until.modules.gamemaster
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class GameEntityIdentifierValueAttribute : Attribute
    {
        public object Value { get; private set; }

        public GameEntityIdentifierValueAttribute(object value)
        {
            Value = value;
        }

        public GameEntityIdentifier createGameEntityIdentifier()
        {
            return new GameEntityIdentifier(Value);
        }
    }
}

