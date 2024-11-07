using Avalonia.Controls;
using Editor.Components;

namespace Editor.Views.Components;
public partial class TransformCompView : UserControl
{
    private Transform _transform;
    public TransformCompView()
    {
        InitializeComponent();
        
        _transform = new Transform();
        DataContext = _transform;
    }
}