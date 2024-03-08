/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using ItemModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Helper
    {
        private static Random _random = new Random();
        public static Random Random { get => _random; }
        public static int CropTypesCount
        {
            get
            {
                int count = 0;
                foreach (CropType item in Enum.GetValues(typeof(CropType)))
                {
                    count++;
                }
                return count;
            }
        }
        public static T?[] DeepCopy<T>(T?[] arr) where T : class, ICloneable
        {
            T?[] copy = new T?[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] is null) copy[i] = null;
                else copy[i] = (T)arr[i].Clone();
            }
            return copy;
        }

        public static List<T> DeepCopy<T>(List<T> list) where T : class, ICloneable
        {
            List<T> copy = new List<T>();
            foreach (T item in list)
            {
                if (item is null) copy.Add(null);
                else copy.Add((T)item.Clone());
            }
            return copy;
        }

        public static bool IsLegalIndex<T>(List<T> list, int index)
        {
            return index >= 0 && index < list.Count;
        }

        public static bool IsLegalIndex<T>(T?[] arr, int index)
        {
            return index >= 0 && index < arr.Length;
        }

        public static CropType ConvertStringToCropType(string cropType)
        {
            switch (cropType)
            {
                case "Blueberry":
                    return CropType.Blueberry;
                case "Carrot":
                    return CropType.Carrot;
                case "Garlic":
                    return CropType.Garlic;
                case "Raspberry":
                    return CropType.Raspberry;
                case "Tomato":
                    return CropType.Tomato;
                default:
                    throw new Exception("Invalid crop type");
            }
        }

        public static bool IsEmptyAt<T>(int index, T[] array)
        {
            return (array[index] == null);
        }

        public static string NullableArrayToString<T>(T?[] arr) where T : class
        {
            string result = "";
            foreach (var item in arr)
            {
                result += (item is null) ? "Empty" : item.ToString();
                result += ";\n ";
            }
            return result;
        }

    }
}
