// east east fight Textdatei
// dotnet run < dieInFight.txt
// cmd instead of powershell 

const string NORTH = "north";
const string EAST = "east";
const string SOUTH = "south";
const string WEST = "west";
const string VALID_OPTION = "Please enter a valid option.";
const string FOUND_EXIT = "You made it! You've found an exit.";
const string NO_KEY = "Sorry, no key here!";

{
    bool IsDead = false;
    bool HasExited = false;
    bool HasWeapon = false;
    bool GoulIsDead = false;
    bool IsValid = true;
    bool FoundKey = false;
    bool TreasureOpen = false;
    string option = string.Empty;
    string room = "IntoScene";
    string a = "";
    string b = "";
    string c = "";
    string d = "";

    PrintWelcome();
    string name = Console.ReadLine()!;
    System.Console.WriteLine($"Good luck, {name}!");
    IntoScene(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen);

    if (TreasureOpen)
    {
        System.Console.WriteLine();
        System.Console.WriteLine();
        System.Console.WriteLine("With the ancient materials and valuable gold the traveller has found, the traveler decides to leave Paris and start a new life with his newfound wealth.");
        System.Console.WriteLine("But he will always remember the catacombs and the spirits that still haunt its depths.");
        System.Console.WriteLine("After leaving Paris with his newfound wealth, the traveler decides to invest the money in various industries, including renewable energy and education.");
        System.Console.WriteLine("He uses the ancient materials he found in the treasure room to fund archaeological research and preservation projects.");
        System.Console.WriteLine("As his businesses grow, the traveler becomes well-known for his philanthropic work and is invited to speak at conferences around the world.");
        System.Console.WriteLine("He becomes an advocate for sustainability and environmental conservation, using his wealth and influence to promote positive change.");
        System.Console.WriteLine("Years go by, and the traveler looks back on his adventure in the catacombs as a turning point in his life. ");
        System.Console.WriteLine("He realizes that it was a pivotal moment that led him to his true calling, and he feels grateful for the opportunity to use his wealth to make a positive impact on the world.");
    }   

    if (IsDead || HasExited)
    {
        return;
    }
}
void CheckIfWeapon(ref string a, ref string b, ref string c, ref string d, ref string room, ref string option, ref bool HasExited, ref bool IsValid, ref bool HasWeapon, ref bool GoulIsDead, ref bool IsDead, ref bool FoundKey, ref bool TreasureOpen)
{
    if (HasWeapon)
    {
        if (GoulIsDead == false)
        { System.Console.WriteLine("You kill the Goul with the knife you found earlier."); GoulIsDead = true; }
        do
        {
            FindOptionsForRoom(room, ref a, ref b, ref c, ref d);
            System.Console.WriteLine($"c) {c}");
            System.Console.WriteLine($"d) {d}");
            option = Console.ReadLine()!;
            switch (option)
            {
                case "c": System.Console.Write(FOUND_EXIT); HasExited = true; break;
                case "d": ShowSkeletons(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
            }
        }
        while (!IsValid);
    }
    else
    {
        System.Console.Write("The Goul-like creature has killed you");
        IsDead = true;
    }
}
void FindOptionsForRoom(string room, ref string a, ref string b, ref string c, ref string d)
{
    switch (room)
    {
        case "IntoScene": a = NORTH; b = EAST; c = SOUTH; d = WEST; break;
        case "HauntedRoom": a = NORTH; b = EAST; c = SOUTH; d = WEST; break;
        case "ShowSkeletons": a = NORTH; b = EAST; c = WEST; d = ""; break;
        case "StrangeCreature": a = "fight"; b = "flee"; c = SOUTH; d = WEST; break;
        case "ShowShadowFigure": a = NORTH; b = EAST; c = SOUTH; d = ""; break;
        case "CameraScene": a = NORTH; b = SOUTH; c = ""; d = ""; break;
        case "KeyRoom": a = "drawers"; b = "closet"; c = "under the bed"; d = "behind the painting"; break;
        case "BabyCreature": a = "yes"; b = "no"; break;
        case "WhichDirection": a = NORTH; b = EAST; c = SOUTH; break;
        case "KeepSearching": a = "keep searching"; b = "pick a direction"; break;
        case "TreasureRoom": a = NORTH; b = EAST; c = WEST; break;
    }
}
string ShowOptions(string room, ref string a, ref string b, ref string c, ref string d, ref string option, ref bool IsValid)
{
    do
    {
        System.Console.WriteLine("Options:");
        FindOptionsForRoom(room, ref a, ref b, ref c, ref d);
        if (room == "IntoScene" || room == "KeyRoom" || room == "HauntedRoom")
        {
            System.Console.WriteLine($"a) {a}");
            System.Console.WriteLine($"b) {b}");
            System.Console.WriteLine($"c) {c}");
            System.Console.WriteLine($"d) {d}");
            option = Console.ReadLine()!;
            if (option != "a" && option != "b" && option != "c" && option != "d")
            {
                System.Console.WriteLine(VALID_OPTION);
                IsValid = false;
            }
            else
            {
                IsValid = true;
            }
        }
        else if (room == "CameraScene" || room == "StrangeCreature" || room == "BabyCreature" || room == "KeepSearching")
        {
            System.Console.WriteLine($"a) {a}");
            System.Console.WriteLine($"b) {b}");
            option = Console.ReadLine()!;
            if (option != "a" && option != "b")
            {
                System.Console.WriteLine(VALID_OPTION);
                IsValid = false;
            }
            else
            {
                IsValid = true;
            }
        }
        else
        {
            System.Console.WriteLine($"a) {a}");
            System.Console.WriteLine($"b) {b}");
            System.Console.WriteLine($"c) {c}");
            option = Console.ReadLine()!;
            if (option != "a" && option != "b" && option != "c")
            {
                System.Console.WriteLine(VALID_OPTION);
                IsValid = false;
            }
            else
            {
                IsValid = true;
            }
        }
    }
    while (!IsValid);
    return option;
}
void IntoScene(ref string a, ref string b, ref string c, ref string d, ref string room, ref string option, ref bool HasExited, ref bool IsValid, ref bool HasWeapon, ref bool GoulIsDead, ref bool IsDead, ref bool FoundKey, ref bool TreasureOpen)
{
    room = "IntoScene";
    System.Console.WriteLine("You are at a crossroads, and you can choose to go down any of the four hallways. Where would you like to go?");
    option = ShowOptions(room, ref a, ref b, ref c, ref d, ref option, ref IsValid);
    switch (option)
    {
        case "a": System.Console.Write("You find that this door opens into a wall."); break;
        case "b": ShowSkeletons(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
        case "c": HauntedRoom(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
        case "d": ShowShadowFigure(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
    }
}
void HauntedRoom(ref string a, ref string b, ref string c, ref string d, ref string room, ref string option, ref bool HasExited, ref bool IsValid, ref bool HasWeapon, ref bool GoulIsDead, ref bool IsDead, ref bool FoundKey, ref bool TreasureOpen)
{
    room = "HauntedRoom";
    System.Console.WriteLine("You hear strange voices. You think you have awoken some of the dead. Where would you like to go?");
    option = ShowOptions(room, ref a, ref b, ref c, ref d, ref option, ref IsValid);
    switch (option)
    {
        case "a": IntoScene(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
        case "b": System.Console.Write(FOUND_EXIT); HasExited = true; break;
        case "c": System.Console.Write("Multiple Goul-like creatures start emerging as you enter the room. You are killed."); IsDead = true; break;
        case "d": TreasureRoom(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
    }
}
void ShowSkeletons(ref string a, ref string b, ref string c, ref string d, ref string room, ref string option, ref bool HasExited, ref bool IsValid, ref bool HasWeapon, ref bool GoulIsDead, ref bool IsDead, ref bool FoundKey, ref bool TreasureOpen)
{
    room = "ShowSkeletons";
    System.Console.WriteLine("You see a wall of skeletons as you walk into the room. Someone is watching you. Where would you like to go?");
    option = ShowOptions(room, ref a, ref b, ref c, ref d, ref option, ref IsValid);
    switch (option)
    {
        case "a": System.Console.Write("You find that this door opens into a wall. You open some of the drywall to discover a knife. "); HasWeapon = true; ShowSkeletons(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
        case "b": StrangeCreature(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
        case "c": IntoScene(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
    }
}
void StrangeCreature(ref string a, ref string b, ref string c, ref string d, ref string room, ref string option, ref bool HasExited, ref bool IsValid, ref bool HasWeapon, ref bool GoulIsDead, ref bool IsDead, ref bool FoundKey, ref bool TreasureOpen)
{
    room = "StrangeCreature";
    if (!GoulIsDead)
    {
        System.Console.WriteLine("A strange Goul-like creature has appeared. You can either run or fight it. What would you like to do?");
    }
    else
    {
        System.Console.WriteLine("You see the Goul-like creature that you killed earlier. What a relief! Where would you like to go?");
        CheckIfWeapon(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen);
    }
    if (HasExited == false)
    {
        option = ShowOptions(room, ref a, ref b, ref c, ref d, ref option, ref IsValid);
        switch (option)
        {
            case "b": ShowSkeletons(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
            case "a": CheckIfWeapon(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
        }
    }

}
void ShowShadowFigure(ref string a, ref string b, ref string c, ref string d, ref string room, ref string option, ref bool HasExited, ref bool IsValid, ref bool HasWeapon, ref bool GoulIsDead, ref bool IsDead, ref bool FoundKey, ref bool TreasureOpen)
{
    room = "ShowShadowFigure";
    System.Console.WriteLine("You see a dark shadowy figure appear in the distance. You are creeped out. Where would you like to go?");
    option = ShowOptions(room, ref a, ref b, ref c, ref d, ref option, ref IsValid);
    switch (option)
    {
        case "a": KeyRoom(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
        case "b": IntoScene(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
        case "c": System.Console.Write("You find that this door opens into a wall."); break;
    }
}
void CameraScene(ref string a, ref string b, ref string c, ref string d, ref string room, ref string option, ref bool HasExited, ref bool IsValid, ref bool HasWeapon, ref bool GoulIsDead, ref bool IsDead, ref bool FoundKey, ref bool TreasureOpen)
{
    room = "CameraScene";
    System.Console.WriteLine("You see a camera that has been dropped on the ground. Someone has been here recently. Where would you like to go?");
    option = ShowOptions(room, ref a, ref b, ref c, ref d, ref option, ref IsValid);
    switch (option)
    {
        case "a": System.Console.Write(FOUND_EXIT); HasExited = true; break;
        case "b": ShowShadowFigure(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
    }
}
void PrintWelcome()
{
    System.Console.WriteLine("Welcome to the Adventure Game!");
    System.Console.WriteLine("==============================");
    System.Console.WriteLine("As an avid traveler, you have decided to visit the Catacombs of Paris.");
    System.Console.WriteLine("However, during your exploration, you find yourself lost.");
    System.Console.WriteLine("You can choose to walk in multiple directions to find a way out.");
    System.Console.Write("Let's start with your name: ");
}
void KeyRoom(ref string a, ref string b, ref string c, ref string d, ref string room, ref string option, ref bool HasExited, ref bool IsValid, ref bool HasWeapon, ref bool GoulIsDead, ref bool IsDead, ref bool FoundKey, ref bool TreasureOpen)
{
    room = "KeyRoom";
    System.Console.WriteLine("You have entered the KeyRoom. You know there must be a key hidden somewhere that leads to a valuable ancient treasure. Choose an option to search for the key! ");
    option = ShowOptions(room, ref a, ref b, ref c, ref d, ref option, ref IsValid);
    switch (option)
    {
        case "a": System.Console.WriteLine(NO_KEY); System.Console.WriteLine("Do you want to keep searching or do you want to go a different direction?"); room = "KeepSearching"; option = ShowOptions(room, ref a, ref b, ref c, ref d, ref option, ref IsValid); HelpFindRoom(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
        case "b": System.Console.WriteLine(NO_KEY); System.Console.WriteLine("Do you want to keep searching or do you want to go a different direction?"); room = "KeepSearching"; option = ShowOptions(room, ref a, ref b, ref c, ref d, ref option, ref IsValid); HelpFindRoom(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
        case "c": System.Console.WriteLine("You see a goul - like baby creature that has been hiding under there. It seems non dangerous. Do you wanna help it?"); room = "BabyCreature"; option = ShowOptions(room, ref a, ref b, ref c, ref d, ref option, ref IsValid); HelpFindRoom(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
        case "d": System.Console.WriteLine("You have found a silver rusty key. Which direction do you want to go now? "); room = "WhichDirection"; FoundKey = true; WhichDirection(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
    }
}
void HelpFindRoom(ref string a, ref string b, ref string c, ref string d, ref string room, ref string option, ref bool HasExited, ref bool IsValid, ref bool HasWeapon, ref bool GoulIsDead, ref bool IsDead, ref bool FoundKey, ref bool TreasureOpen)
{
    if (room == "KeepSearching")
    {
        switch (option)
        {
            case "a": KeyRoom(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
            case "b": System.Console.WriteLine("Choose a direction! "); WhichDirection(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
        }
    }
    if (room == "BabyCreature")
    {
        switch (option)
        {
            case "a": System.Console.WriteLine("You try holding the baby creature when you feel a slimy acid substance burn through your skin. It was a trap by the Gouls. An army of Gouls storm through the door and kill you."); IsDead = true; break;
            case "b": System.Console.WriteLine("You decide to ignore the creature. This decision saved your LIFE! You now must choose a direction."); WhichDirection(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
        }
    }
    if (IsDead == false && HasExited == false)
    {
        WhichDirection(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen);
    }
}
void WhichDirection(ref string a, ref string b, ref string c, ref string d, ref string room, ref string option, ref bool HasExited, ref bool IsValid, ref bool HasWeapon, ref bool GoulIsDead, ref bool IsDead, ref bool FoundKey, ref bool TreasureOpen)
{
    room = "WhichDirection";
    option = ShowOptions(room, ref a, ref b, ref c, ref d, ref option, ref IsValid);
    switch (option)
    {
        case "a": CameraScene(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
        case "b": System.Console.WriteLine(FOUND_EXIT); HasExited = true; break;
        case "c": ShowShadowFigure(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
    }
}
void TreasureRoom(ref string a, ref string b, ref string c, ref string d, ref string room, ref string option, ref bool HasExited, ref bool IsValid, ref bool HasWeapon, ref bool GoulIsDead, ref bool IsDead, ref bool FoundKey, ref bool TreasureOpen)
{
    room = "TreasureRoom";
    if (FoundKey)
    {
        System.Console.WriteLine("Here lies the big ancient treasure. You cant help but open it with the key you found earlier and discover ancient material as well as valuable gold. You must now escape with it and be careful to not die! Which direction would you like to go?");
        TreasureOpen = true;
    }
    else
    {
        System.Console.WriteLine("You see a treasure in the middle of the room and wonder what it is worth. Theres a room with a key that you must find to unlock the treasure which contains valuable gold. Where could that room be? Choose a direction!");
    }
    option = ShowOptions(room, ref a, ref b, ref c, ref d, ref option, ref IsValid);
    switch (option)
    {
        case "a": HauntedRoom(ref a, ref b, ref c, ref d, ref room, ref option, ref HasExited, ref IsValid, ref HasWeapon, ref GoulIsDead, ref IsDead, ref FoundKey, ref TreasureOpen); break;
        case "b": System.Console.WriteLine(FOUND_EXIT); HasExited = true; break;
        case "c": System.Console.WriteLine("The Gouls have been hunting you down and following you for a while. they cant let you take the gold of the treasure, so they killed you."); IsDead = true; break;
    }
}
