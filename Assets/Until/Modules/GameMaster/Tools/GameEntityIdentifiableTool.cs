using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using UnityEngine;
using UnityEditor;
using until.system;
using until.utils;
using until.develop;


namespace until.modules.gamemaster
{
    public class GameEntityIdentifiableTool
    {
        [MenuItem("Until/GameEntityIdentifiableTool")]
        static void execute()
        {
            var entry_code = "";
            var thistype = typeof(GameEntityIdentifiableTool);
            var assemble = thistype.Assembly;
            var types = assemble.GetTypes();
            var namespaces = new HashSet<string>();
            namespaces.Add(thistype.Namespace);

            foreach (var type in types)
            {
                var attribute = type.GetCustomAttribute<GameEntityIdentifiableAttribute>();
                if (attribute == null)
                {
                    continue;
                }
                var values = type.GetEnumValues();
                namespaces.Add(type.Namespace);
                foreach (var value in values)
                {
                    var identifier = new GameEntityIdentifier(value);
                    var name = identifier.Expression.Replace(".", "_");
                    entry_code += $"[GameEntityIdentifierValue({type.Name}.{value})]\r\n";
                    entry_code += $"{name},\r\n";
                }
            }

            var namespace_code = "";
            foreach(var ns in namespaces)
            {
                namespace_code += $"using {ns};\r\n";
            }

            // スクリプトを書き換えて出力
            var script = File.ReadAllText("Assets/Until/Modules/GameMaster/Tools/GameEntityIdentifiableScriptTemplate.cs");
            script = script.Replace("@namespace", namespace_code);
            script = script.Replace("@entry", entry_code);
            script = script.Replace("SCRIPT_TEMPLATE", "true");
            File.WriteAllText("Assets/Generated/GameMaster/GameEntityIdentifiable.cs", script);
            AssetDatabase.Refresh();
        }
    }
}
