namespace XmlDeserializersTestApp
{
    public interface IDeserializer<T>
    {
        T Deserialize(string data);
    }
}
