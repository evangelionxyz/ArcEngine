using System.ComponentModel;
using Editor.Core;

namespace Editor.Components;
public class Transform : INotifyPropertyChanged
{
    private Vector3f _position;
    private Vector3f _rotation;
    private Vector3f _scale;

    public Vector3f Position
    {
        get => _position;
        set { _position = value; OnPropertyChanged(nameof(Position)); }
    }
    
    public Vector3f Rotation
    {
        get => _rotation;
        set { _rotation = value; OnPropertyChanged(nameof(Rotation)); }
    }
    
    public Vector3f Scale
    {
        get => _scale;
        set { _scale = value; OnPropertyChanged(nameof(Scale)); }
    }

    public Transform()
    {
        Position = new Vector3f();
        Rotation = new Vector3f();
        Scale = new Vector3f();
    }

    public Transform(Vector3f position, Vector3f rotation, Vector3f scale)
    {
        _position = position;
        _rotation = rotation;
        _scale = scale;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}