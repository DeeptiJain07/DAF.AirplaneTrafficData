﻿using System;
using System.ComponentModel;
using System.Linq;

namespace DAF.AirplaneTrafficData.HelperClasses
{
    public static class EnumExtensions
    {
        /// <summary>
        ///     Get Description
        /// </summary>
        /// <returns>
        ///     string
        /// </returns>
        /// <param name="genericEnum">TypeDetail</param>
        public static string GetDescription(this Enum genericEnum)
        {
            var genericEnumType = genericEnum.GetType();
            var memberInfo = genericEnumType.GetMember(genericEnum.ToString());
            if (memberInfo.Length > 0)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Any()) return ((DescriptionAttribute)attributes.ElementAt(0)).Description;
            }

            return genericEnum.ToString();
        }
    }
}