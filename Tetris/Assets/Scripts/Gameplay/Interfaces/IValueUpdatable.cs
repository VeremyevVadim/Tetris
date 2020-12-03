using System;

public interface IValueUpdatable
{
    event Action OnValueUpdated;
}
