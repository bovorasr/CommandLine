﻿using System;
using System.ComponentModel;

namespace CommandLine.Attributes.Advanced
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class ArgumentGroupAttribute : GroupAttribute
    {
        public string Name { get; private set; }

        public ArgumentGroupAttribute(string name)
        {
            Name = name;
        }
    }
}
