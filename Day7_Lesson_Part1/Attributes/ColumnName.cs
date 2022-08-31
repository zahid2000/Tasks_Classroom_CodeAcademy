using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_Lesson_Part1.Attributes;

public class ColumnName:Attribute
{
    private string? _displayName;
	public ColumnName() {}
	public ColumnName(string displayName) { _displayName = displayName; }
	public string? DisplayName => _displayName;

}
