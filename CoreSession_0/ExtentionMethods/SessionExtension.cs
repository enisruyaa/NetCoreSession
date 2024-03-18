namespace Newtonsoft.Json
{
    public static class SessionExtension
    {

        //Bir metodun Extention metod olabilmesi için ilk parametesinin çok özel olması gerekir. Bu ilk parametre verilirken this keyword'u ile başlamalıdır. Ve entegre edilmek istendiği tip seçilmelidir ki o tip içerisinde o metod yer alsın.. Sonra diğer parametreler normal bir şekilde verilir...

        public static void SetObject(this ISession session,string key , object value)
        {
            string serializedObject = JsonConvert.SerializeObject(value);
            session.SetString(key, serializedObject);
        }

        public static T GetObject<T>(this ISession session,string key) where T : class 
        {
            string serializedObject = session.GetString(key);
            if (string.IsNullOrEmpty(serializedObject))
            {
                return null;
            }
            T deserializedObject = JsonConvert.DeserializeObject<T>(serializedObject);
            return deserializedObject;
        }
    }
}
