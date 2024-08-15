using System.ComponentModel;
using System.Reflection;

namespace DeployTemplateManager.Helpers
{
    public static class EnumExtensions
    {
        /// <summary>
        /// 取得 Enum 的 Description
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();

            return attribute == null ? value.ToString() : attribute.Description;
        }

        /// <summary>
        /// 將 Enum 轉換為 Description
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryParseWithDescription<T>(string description, out T result) where T : struct
        {
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                var enumValue = (Enum)value;
                if (enumValue.GetDescription().Equals(description, StringComparison.OrdinalIgnoreCase))
                {
                    result = (T)value;
                    return true;
                }
            }
            result = default;
            return false;
        }
    }
}
