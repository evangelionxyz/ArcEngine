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
            new Node("Animals", new ObservableCollection<Node>
            {
                new Node("Mammals", new ObservableCollection<Node>
                {
                    new Node("Lion"), new Node("Cat"), new Node("Zebra")
                })
            })
        };
    }
}