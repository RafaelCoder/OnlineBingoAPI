using System;

namespace OnlineBingoAPI.Extensions
{
    public static class AdaptExtension
    {
        public static T Adapt<T>(this object obj)
        {
            T targetItem = Activator.CreateInstance<T>();
            var props = typeof(T).GetProperties();
            var targetProps = obj.GetType().GetProperties();
            foreach (var prop in props)
            {
                foreach (var targetProp in targetProps)
                {
                    if (prop.Name == targetProp.Name)
                    {
                        targetProp.SetValue(targetItem, prop.GetValue(obj));
                        //assign

                    }
                }
            }
            return targetItem;
        }
    }
}
