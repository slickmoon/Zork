namespace Zork
{
    public enum Actions { Move, Inventory, Attack, Look, Blank, Exit, Help, Use, Teleport, Take, Drop, Put};
    public enum Directions { East, West, North, South, Up, Down };
    
    public enum MovementTypes { Walking, Teleport, Fall };
    public enum ItemMovements { Take, Put, Drop };
}
