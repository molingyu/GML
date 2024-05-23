namespace GUML;

public interface IPosInfo
{
    public int Start { get; set; }
    public int End { get; set; }
    public int Line { get; set; }
    public int Column { get; set; }
}

public class GumlSyntaxNode : IPosInfo
{
    public List<GumlSyntaxNode> Children { get; } = [];
    public List<GumlEachNode> EachNodes { get; } = [];
    public Dictionary<string, (bool, GumlExprNode)> Properties { get; } = new();
    public Dictionary<string, string> Signals { get; } = new();

    public required string Name { get; init; }
    public int Start { get; set; }
    public int End { get; set; }
    public int Line { get; set; }
    public int Column { get; set; }
}
