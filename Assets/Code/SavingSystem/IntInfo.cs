using UnityEngine;

public class IntInfo : DataInfo<int>
{
    public string Id => id;
    int defaultValue;
    public int Value
    {
        get => Load();
        set
        {
            Save(value);
        }
    }
    

    public IntInfo(string id, int defaultValue)
    {
        this.id = id;
        this.defaultValue = defaultValue;
    }
    
    public override void Save(int value)
    {
        this.value = value;
        PlayerPrefs.SetInt(id, value);   
        PlayerPrefs.Save();
    }
    
    public override int Load()
    {
        return PlayerPrefs.GetInt(id, defaultValue);
    }
}