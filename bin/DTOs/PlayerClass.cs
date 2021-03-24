
public class PlayerClass
{
    public string _id { get; set; }
    public int index { get; set; }
    public string name { get; set; }
    public int hit_die { get; set; }
    public Proficiency_Choices[] proficiency_choices { get; set; }
    public Proficiency[] proficiencies { get; set; }
    public Saving_Throws[] saving_throws { get; set; }
    public Starting_Equipment starting_equipment { get; set; }
    public Class_Levels class_levels { get; set; }
    public Subclass[] subclasses { get; set; }
    public string url { get; set; }
}

public class Starting_Equipment
{
    public string url { get; set; }
    public string _class { get; set; }
}

public class Class_Levels
{
    public string url { get; set; }
    public string _class { get; set; }
}

public class Proficiency_Choices
{
    public From[] from { get; set; }
    public string type { get; set; }
    public int choose { get; set; }
}

public class From
{
    public string name { get; set; }
    public string url { get; set; }
}

public class Proficiency
{
    public string url { get; set; }
    public string name { get; set; }
}

public class Saving_Throws
{
    public string url { get; set; }
    public string name { get; set; }
}

public class Subclass
{
    public string name { get; set; }
    public string url { get; set; }
}
