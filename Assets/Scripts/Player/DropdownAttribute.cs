using System;

internal class DropdownAttribute : Attribute
{
    private string v;

    public DropdownAttribute(string v)
    {
        this.v = v;
    }
}