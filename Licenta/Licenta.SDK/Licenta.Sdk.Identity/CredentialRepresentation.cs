namespace Licenta.Sdk.Identity
{
    public class CredentialRepresentation
    {
        public string Type { get; set; } = "";
        public bool Temporary { get; set; } = false;
        public string Value { get; set; } = "";
        public CredentialRepresentation() { }
        public CredentialRepresentation(string type, bool temporary, string value)
        {
            Type = type;
            Temporary = temporary;
            Value = value;
        }

    }
}
