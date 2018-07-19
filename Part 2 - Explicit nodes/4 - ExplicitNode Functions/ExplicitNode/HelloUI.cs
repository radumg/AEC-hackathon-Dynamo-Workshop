using System;
using System.Collections.Generic;
using System.Linq;
/* dynamo directives */
using Dynamo.Graph.Nodes;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;

namespace DynamoWorkshop.ExplicitNode
{
  [NodeName("HelloUI")]
  [NodeDescription("Sample Explicit Node")]
  [NodeCategory("DynamoWorkshop.Explicit Node")]
  [OutPortNames("Color")]
  [OutPortTypes("color")]
  [OutPortDescriptions("Selected Color")]
  [IsDesignScriptCompatible]
  public class HelloUI : NodeModel
  {
    //Json Constructor for Dynamo 2.0 nodes
    [JsonConstructor]
    private HelloUI(IEnumerable<PortModel> inPorts, IEnumerable<PortModel> outPorts) : base(inPorts, outPorts)
    {

    }

    public HelloUI()
    {
      RegisterAllPorts();
    }

    private int _sliderValueA;
    private int _sliderValueR;
    private int _sliderValueB;
    private int _sliderValueG;
    public int SliderValueA { get => _sliderValueA;  set { _sliderValueA = value; RaisePropertyChanged("SliderValueA"); OnNodeModified(); }}
    public int SliderValueR { get => _sliderValueR;  set { _sliderValueR = value; RaisePropertyChanged("SliderValueR"); OnNodeModified(); } }
    public int SliderValueB { get => _sliderValueB;  set { _sliderValueB = value; RaisePropertyChanged("SliderValueB"); OnNodeModified(); } }
    public int SliderValueG { get => _sliderValueG;  set { _sliderValueG = value; RaisePropertyChanged("SliderValueG"); OnNodeModified(); } }

    public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
    {
      var sliderValueA = AstFactory.BuildDoubleNode(SliderValueA);
      var sliderValueR = AstFactory.BuildDoubleNode(SliderValueR);
      var sliderValueG = AstFactory.BuildDoubleNode(SliderValueG);
      var sliderValueB = AstFactory.BuildDoubleNode(SliderValueB);

      var functionCall =
        AstFactory.BuildFunctionCall(
          new Func<int, int, int, int, System.Drawing.Color>(Functions.Functions.ColorByARGB),
          new List<AssociativeNode> { sliderValueA, sliderValueR, sliderValueG, sliderValueB });

      return new[] { AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), functionCall) };
    }
  }
}
