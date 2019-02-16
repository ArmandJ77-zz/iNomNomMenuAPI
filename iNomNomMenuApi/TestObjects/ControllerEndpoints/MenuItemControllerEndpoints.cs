namespace TestObjects.ControllerEndpoints
{
    public static class MenuItemControllerEndpoints
    {
        public static string baseEndpoint => "api/menuitem";

        public static string GetList(int pagesize,int page) => $"{baseEndpoint}/{pagesize}/{page}";
        public static string Get(int id) => $"{baseEndpoint}/{id}";
        public static string Create => baseEndpoint;
        public static string Update => baseEndpoint;
        public static string Delete(int id) => $"{baseEndpoint}/{id}";
    }
}
