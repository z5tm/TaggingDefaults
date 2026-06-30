namespace TaggingDefaults;

using RueI.API.Elements;

public static class DefaultTags
{
    public static class Items
    {
        public static readonly Tag ItemTooltipTag = new("ItemTooltipTag");
        public static readonly Tag ItemOverlayTag = new("ItemOverlayTag");
    }
    public static class GenericInformation
    {
        public static readonly Tag Error = new("Error");
        public static readonly Tag Warning = new("Warning");
        public static readonly Tag Information = new("Information");
        public static readonly Tag Success = new("Success");
    }
}