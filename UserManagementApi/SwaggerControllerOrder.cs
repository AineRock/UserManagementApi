using System.Reflection;

namespace UserManagementApi
{
    public class SwaggerControllerOrder<T>
    {
        private readonly Dictionary<string, uint> orders;
        public SwaggerControllerOrder(Assembly assembly)
            : this(GetFromAssembly<T>(assembly)) { }

        public SwaggerControllerOrder(IEnumerable<Type> controllers)
        {

            orders = new Dictionary<string, uint>(
                controllers.Where(c => c.GetCustomAttributes<SwaggerControllerOrderAttribute>().Any())
                .Select(c => new { Name = ResolveControllerName(c.Name), c.GetCustomAttribute<SwaggerControllerOrderAttribute>().Order })
                .ToDictionary(v => v.Name, v => v.Order), StringComparer.OrdinalIgnoreCase);
        }

        public static IEnumerable<Type> GetFromAssembly<TController>(Assembly assembly)
        {
            return assembly.GetTypes().Where(c => typeof(TController).IsAssignableFrom(c));
        }
        private static string ResolveControllerName(string name)
        {
            const string suffix = "Controller";

            if (name.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
                return name.Substring(0, name.Length - suffix.Length);
            return name;
        }

        private uint Order(string controller)
        {
            if (!orders.TryGetValue(controller, out uint order))
                order = uint.MaxValue;

            return order;
        }

        public string OrderKey(string controller)
        {
            return Order(controller).ToString("D10");
        }

        public string SortKey(string controller)
        {
            return $"{OrderKey(controller)}_{controller}";
        }
    }
}
