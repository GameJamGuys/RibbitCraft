using UnityEngine;

public class FloatInfo : DataInfo<float>
{
    public string Id => id;
    float defaultValue;
    public float Value
    {
        get => Load();
        set
        {
            Save(value);
        }
    }
    
    public FloatInfo(string id, float defaultValue)
    {
        this.id = id;
        this.defaultValue = defaultValue;
    }

    public override void Save(float value)
    {
        this.value = value;
        PlayerPrefs.SetFloat(id, value);
    }

    public override float Load()
    {
        return PlayerPrefs.GetFloat(id, defaultValue);
    }
}