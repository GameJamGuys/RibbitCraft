using UnityEngine;

public class StringInfo : DataInfo<string>
{
    public string Id => id;
    string defaultValue;
    public string Value
    {
        get => Load();
        set
        {
            Save(value);
        }
    }

    public StringInfo(string id, string defaultValue)
    {
        this.id = id;
        this.defaultValue = defaultValue;
    }
    
    public override void Save(string value)
    {
        this.value = value;
        PlayerPrefs.SetString(id, value);
        PlayerPrefs.Save();
    }
    
    public override string Load()
    {
        return PlayerPrefs.GetString(id, defaultValue);   
    }
}