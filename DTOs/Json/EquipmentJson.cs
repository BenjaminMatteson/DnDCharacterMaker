using System;
using System.Collections.Generic;

public namespace Json
{
    public class EquipmentCategory
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    public class Cost
    {
        public int quantity { get; set; }
        public string unit { get; set; }
    }

    public class DamageType
    {
        public string name { get; set; }
        public string index { get; set; }
        public string url { get; set; }
    }

    public class Damage
    {
        public string damage_dice { get; set; }
        public DamageType damage_type { get; set; }
    }

    public class Range
    {
        public int normal { get; set; }
        public int @long { get; set; }
    }

    public class Property
    {
        public string name { get; set; }
        public string index { get; set; }
        public string url { get; set; }
    }

    public class EquipmentJson
    {
        public string index { get; set; }
        public string name { get; set; }
        public EquipmentCategory equipment_category { get; set; }
        public string weapon_category { get; set; }
        public string weapon_range { get; set; }
        public string category_range { get; set; }
        public Cost cost { get; set; }
        public Damage damage { get; set; }
        public Range range { get; set; }
        public int weight { get; set; }
        public List<Property> properties { get; set; }
        public string url { get; set; }
    }
}