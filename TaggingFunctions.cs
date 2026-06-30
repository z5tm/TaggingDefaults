using RueI.API.Elements;

namespace TaggingDefaults;

public static class TaggingFunctions
{
    public static List<Tag>.Enumerator GetEnumerator() => GetAllTags().GetEnumerator();
    public static void ClearCache() => _cachedList = null;
    public static List<Tag> All => GetAllTags();
    private static List<Tag>? _cachedList;
	
    private static List<Tag> GetAllTags()
    {
        if (_cachedList != null)
            return _cachedList;
        
        _cachedList = [];
        
        var fields = typeof(DefaultTags).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
        
        foreach (var field in fields.Where(fld => fld.FieldType == typeof(Tag) && fld.IsInitOnly))
            _cachedList.Add((Tag)field.GetValue(null));
        
        var nestedTypes = typeof(DefaultTags).GetNestedTypes(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
        foreach (var field in nestedTypes
                     .SelectMany(type => type.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
                     .Where(fld => fld.FieldType == typeof(Tag) && fld.IsInitOnly)))
            _cachedList.Add((Tag)field.GetValue(null));
        
        return _cachedList;
    }
}