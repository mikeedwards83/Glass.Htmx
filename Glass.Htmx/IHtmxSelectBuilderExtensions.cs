namespace Glass.Htmx
{
    public static class IHtmxSelectBuilderExtensions
    {
        public static T SelectThis<T>(this T builder) where T : IHtmxSelectBuilder
        {
            builder.Append(Constants.This);
            return builder;
        }
       
        public static T Select<T>(this T builder, string selector) where T : IHtmxSelectBuilder
        {
            builder.Append($"{selector}");
            return builder;
        }
      
        public static T Closest<T>(this T builder, string selector) where T: IHtmxSelectBuilder
        {
            builder.Append($"{Directions.Closest} {selector}");
            return builder;
        }

        public static T Find<T>(this T builder, string selector) where T : IHtmxSelectBuilder
        {
            builder.Append($"{Directions.Find} {selector}");
            return builder;
        }

        public static T Next<T>(this T builder, string selector = null) where T : IHtmxSelectBuilder
        {
            builder.Append($"{Directions.Next} {selector}");
            return builder;
        }

        public static T Previous<T>(this T builder, string selector = null) where T : IHtmxSelectBuilder
        {
            builder.Append($"{Directions.Previous} {selector}");
            return builder;
        }

        public class Directions
        {
            public const string Closest = "closest";
            public const string Find = "find";
            public const string Next = "next";
            public const string Previous = "previous";
        }
    }
}
