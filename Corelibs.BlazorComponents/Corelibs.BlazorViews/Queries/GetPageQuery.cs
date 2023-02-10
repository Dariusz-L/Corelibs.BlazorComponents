using PageTree.App.Entities.Styles;

namespace Corelibs.BlazorViews.Queries;

public sealed record GetPageQuery(string ID);
public sealed record GetPageQueryOut(PageVM PageVM);

public class PageVM
{
    public IdentityVM[] Path { get; init; } = Array.Empty<IdentityVM>();
    public IdentityVM Identity { get; init; } = new IdentityVM();
    public IdentityVM SignatureIdentity { get; init; } = new IdentityVM();
    public PropertyVM[] Properties { get; init; } = Array.Empty<PropertyVM>();
    public IdentityVM[] PracticeTactics { get; init; } = Array.Empty<IdentityVM>();
    public Style? StyleOfPage { get; init; }
    public Style[] StylesOfChildren { get; init; } = Array.Empty<Style>();
}

public class PropertyVM
{
    public IdentityVM Identity { get; init; } = new IdentityVM();
    public IdentityVM SignatureIdentity { get; init; } = new IdentityVM();
    public PropertyVM[] Properties { get; init; } = Array.Empty<PropertyVM>();

    public PropertyType PropertyType { get; init; }

    public bool IsExpanded { get; init; } = true;
    public bool CanExpand { get; init; } = true;
    public bool HasChildren { get; init; }

}

public class IdentityVM
{
    public string ID { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}
