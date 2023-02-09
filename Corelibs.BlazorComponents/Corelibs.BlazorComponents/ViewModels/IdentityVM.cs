namespace Corelibs.BlazorComponents.ViewModels
{
    public class IdentityVM
    {
        public string ID { get; set; } = "";
        public string Name { get; set; } = "";

        public IdentityVM() {}
        public IdentityVM(string id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
