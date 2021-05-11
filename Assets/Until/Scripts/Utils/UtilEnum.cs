using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;



namespace until.utils
{
    // Enum�^�̊g�����\�b�h���`����N���X
    public static class UtilEnum
    {
        /// <summary>
        /// �w��� Attribute ���擾����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <returns>attribute�B������Ȃ��ꍇnull��Ԃ�</returns>
        public static T getAttrubute<T>(this Enum e) where T : Attribute
        {
            var field = e.GetType().GetField(e.ToString());
            if (field.GetCustomAttribute<T>() is T attribute)
            {
                return attribute;
            }

            return null;
        }


        /// <summary>
        /// �w��� Attribute �������Ă��邩�ǂ����B
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool hasAttribute<T>(this Enum e) where T : Attribute
        {
            return getAttrubute<T>(e) != null;
        }
    }
}