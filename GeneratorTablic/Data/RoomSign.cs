// RoomSign.cs

using System.Collections.Generic;

namespace GeneratorTablic.Data
{
    public class RoomSign
    {
        //to teoretycznie do poprawy ale przejdzie od biedy
        public string LogoPath { get; set; } = "/Images/logo.jpg";
        public LogoPosition LogoPosition { get; set; } = new LogoPosition();
        public string RoomNumber { get; set; }
        public FontSettings RoomNumberFont { get; set; } = new FontSettings();
        public List<Person> AssignedPeople { get; set; } = new List<Person>();
        public FontSettings PersonNameFont { get; set; } = new FontSettings();
        public string FileName { get; set; }
    }

    public class LogoPosition
    {
        public PositionAlignment Alignment { get; set; } = PositionAlignment.Left;
        public int Size { get; set; } = 400;
    }

//zeby mozna bylo ustawiac gdziekolwiek logo trzeba bylo sie pobawic generowaniem dokumentu zeby reszte elemntow jakos sensowanie sie ustawiala - nie mialam na to pomyslu
//wiec zrobilam tak - teoretycznie mozna to ulepszyc ale mysel ze tez przejdzie - ja frontu nei lubie i nie chcialo mi sie tym bawic 
    public enum PositionAlignment
    {
        Left,
        Middle,
        Right
    }

    public class FontSettings
    {
        public int Size { get; set; }
        public string Color { get; set; }
        public string FontName { get; set; }
    }
}