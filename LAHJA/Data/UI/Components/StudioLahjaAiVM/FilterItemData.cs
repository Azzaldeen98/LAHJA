using Microsoft.AspNetCore.Components;

namespace LAHJA.Data.UI.Components.StudioLahjaAiVM
{
    public class FilterItemData
    {
        public int Id { get; set; } = 0;
        public string Identifier { get; set; } = string.Empty;
        public Dictionary<string, string> Text { get; set; } = new();
        public string Icon { get; set; } = string.Empty;
        public Type? Component { get; set; }
        public string TypeModel { get; set; } = string.Empty;
    }

    public class StudioFilterDefinition<T>
    {
        public string Title { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public List<T> Options { get; set; } = new();
        public EventCallback<T> OnSelectionChanged { get; set; }
    }

}
