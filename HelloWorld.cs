using Godot;

namespace FantasyWorld;

public partial class HelloWorld : Node
{
    public override void _Ready()
    {
        GD.Print("Hello World");
    }
}