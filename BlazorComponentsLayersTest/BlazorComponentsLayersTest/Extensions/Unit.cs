﻿namespace BlazorComponentsLayersTest.Extensions
{
    public enum Unit
    {
        px,
        rem,
        pt
    }

    public static class UnitExtensions
    {
        public static string GetName(this Unit unit) =>
            unit switch
            {
                Unit.px => "px",
                Unit.rem => "rem",
                Unit.pt => "%",
                _ => ""
            };

        public static Unit FromName(this string unit) =>
            unit switch
            {
                "px" => Unit.px,
                "rem" => Unit.rem,
                "%" => Unit.pt,
                _ => Unit.px
            };
    }
}
