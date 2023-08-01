using System;

// ReSharper disable VirtualMemberCallInConstructor

public abstract class BaseData
{
    public BaseData()
    {
        InitData();
    }
    public abstract void InitData();
    public abstract void SetLocalData();

    public abstract string ToJson();
}