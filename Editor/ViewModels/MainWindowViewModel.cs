using System.Collections.ObjectModel;
using Editor.Models;

namespace Editor.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Node> MyNodes { get; set; }
    
    public MainWindowViewModel()
    {
        MyNodes = new ObservableCollection<Node>
        {
            new Node("Scenes", new ObservableCollection<Node>
            {
                new Node("GameObject 1", new ObservableCollection<Node>
                {
                    new Node("Shape 1"), new Node("Shape 2"), new Node("Shape 3")
                })
            })
        };
    }
}